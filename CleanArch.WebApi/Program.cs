
using CleanArch.Application.Interfaces;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Mappers;
using CleanArch.Application.Services;
using CleanArch.Application.Validators;
using CleanArch.Infrastructure.Services;
using CleanArch.Persistence.Contexts;
using CleanArch.Persistence.Repositories;
using CleanArch.WebApi.Middlewares;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sieve.Sample.Services;
using Sieve.Services;
using System.Reflection;
using static CleanArch.WebApi.Middlewares.ExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CleanArch.WebApi.Middlewares.IExceptionHandler, HandleExceptionAsync>();

// Add services to the container.

//https://dev.to/isaacojeda/explorando-la-autenticacion-bearer-en-aspnet-core-8-5e95 https://dev.to/isaacojeda/explorando-la-autenticacion-bearer-en-aspnet-core-8-5e95
//https://github.com/isaacOjeda/DevToPosts/tree/main/IdentityApiAuth
//https://medium.com/@jasminewith/adding-swagger-to-asp-net-core-mvc-web-api-project-263473ea02a8


builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapper));

#region InfrastructureServices

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<ISieveProcessor, SieveProcessor>();
builder.Services.AddScoped<ISieveCustomSortMethods, SieveCustomSortMethods>();
builder.Services.AddScoped<ISieveCustomFilterMethods, SieveCustomFilterMethods>();
builder.Services.AddTransient<IChoferServices, ChoferServices>();
builder.Services.AddTransient<IExampleService, ExampleService>();
builder.Services.AddTransient<IChoferRepository, ChoferRepository>();
builder.Services.AddTransient<IExampleRepository, ExampleRepository>();

#endregion


builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddHttpClient();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssemblyContaining<ChoferDtoValidator>();
var connectionString = builder.Configuration.GetConnectionString("DbAppConnection");
builder.Services.AddDbContext<DbAppContext>(options =>  options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(typeof(DbAppContext).Assembly.FullName)));
builder.Services.AddEndpointsApiExplorer();
string aditionalInfo = string.Format("Environment: {0}", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));



builder.Services.AddHttpClient<IWeatherService, WeatherService>(client =>
{
	client.BaseAddress = new Uri("https://api.openweathermap.org/");
});
builder.Services.AddSingleton<IWeatherService>(provider =>
{
	var httpClient = provider.GetRequiredService<HttpClient>();
	var apiKey = builder.Configuration["OpenWeatherMap:ApiKey"] ??"";
	return new WeatherService(httpClient, apiKey);
});


builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web.Api", Version = "v1", Description = aditionalInfo });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please insert JWT with Bearer into field",
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					new OpenApiSecurityScheme
					{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
					},
					new string[] { }
				}
				});


});

var app = builder.Build();
// Middleware de excepción
app.Use(async (context, next) =>
{
	var exceptionHandler = context.RequestServices.GetRequiredService<CleanArch.WebApi.Middlewares.IExceptionHandler>();
	try
	{
		await next();
	}
	catch (Exception ex)
	{
		// Manejador personalizado
		var handled = await exceptionHandler.TryHandleAsync(context, ex, context.RequestAborted);
		if (!handled)
		{
			throw;
		}
	}
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Arch"));
}

app.Run();




