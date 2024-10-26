
using CleanArch.Application.Interfaces;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Mappers;
using CleanArch.Application.Services;
using CleanArch.Infrastructure.Services;
using CleanArch.Persistence.Contexts;
using CleanArch.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sieve.Sample.Services;
using Sieve.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

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

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();


if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pick and Go"));
}

app.Run();



/*
 
   public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IPlayerRepository, PlayerRepository>()
                .AddTransient<IClubRepository, ClubRepository>()
                .AddTransient<IStadiumRepository, StadiumRepository>()
                .AddTransient<ICountryRepository, CountryRepository>();
        }
    }
 
 */


