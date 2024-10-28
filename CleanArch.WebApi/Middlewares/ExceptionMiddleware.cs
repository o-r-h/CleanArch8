using CleanArch.WebApi.Classes;
using System.Text.Json;
using FluentValidation;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


namespace CleanArch.WebApi.Middlewares
{
	public class ExceptionMiddleware 
	{


		// MyExceptionHandler.cs
		public class HandleExceptionAsync : IExceptionHandler
		{
			public async ValueTask<bool> TryHandleAsync(
				HttpContext httpContext,
				Exception exception,
				CancellationToken cancellationToken)
			{
				// Verifica si es una excepción de validación
				if (exception is ValidationException validationException)
				{
					httpContext.Response.StatusCode = 400;
					httpContext.Response.ContentType = "application/json";
					List<ValidationError> errors = validationException.Errors
						.Select(e => new ValidationError
						{
							PropertyName = e.PropertyName,
							ErrorMessage = e.ErrorMessage
						})
						.ToList();

					var errorResponse = new ErrorResponse
					{
						Title = "Validation Error",
						Message = "One or more validation errors occurred.",
						StatusCode = 400,
						Errors = errors
					};

					await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
					return true;
				}

				// Manejo genérico de errores no controlados
				httpContext.Response.StatusCode = 500;
				httpContext.Response.ContentType = "application/json";

				var genericErrorResponse = new ErrorResponse
				{
					Title = "An error occurred",
					Message = exception.Message,
					StatusCode = 500
				};

				await httpContext.Response.WriteAsJsonAsync(genericErrorResponse, cancellationToken);
				return true;
			}
		}

		//private static Task HandleExceptionAsync(HttpContext context, Exception exception, CancellationToken cancellationToken) : IExceptionHandler
		//{
		//	context.Response.ContentType = "application/json";

		//	ErrorResponse errorResponse;

		//	if (exception is ValidationException validationException)
		//	{
		//		context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
		//		errorResponse = new ErrorResponse
		//		{
		//			Title = "Validation Error",
		//			Message = string.Join("; ", validationException.Errors.Select(e => e.ErrorMessage)),
		//			StatusCode = context.Response.StatusCode
		//		};
		//	}
		//	else
		//	{
		//		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		//		errorResponse = new ErrorResponse
		//		{
		//			Title = "An error occurred",
		//			Message = exception.Message,
		//			StatusCode = context.Response.StatusCode
		//		};
		//	}

		//	var result = JsonSerializer.Serialize(errorResponse);
		//	return context.Response.WriteAsync(result);
		//}
	}
}
