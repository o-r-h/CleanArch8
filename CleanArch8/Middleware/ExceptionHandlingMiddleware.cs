

namespace CleanArch.Infrastructure.Middleware
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;
		private readonly IWebHostEnvironment _env;

		public ExceptionHandlingMiddleware(
			RequestDelegate next,
			ILogger<ExceptionHandlingMiddleware> logger,
			IWebHostEnvironment env)
		{
			_next = next;
			_logger = logger;
			_env = env;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception exception)
			{
				await HandleExceptionAsync(context, exception);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			_logger.LogError(exception, "Error durante el procesamiento de la solicitud");

			var response = new ErrorResponse(exception, context.TraceIdentifier);

			// En desarrollo, incluimos más detalles del error
			if (_env.IsDevelopment())
			{
				response.Message = exception.ToString();
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = response.StatusCode;

			await context.Response.WriteAsJsonAsync(response);
		}
	}
}
