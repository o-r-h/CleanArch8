using CleanArch.Application.Common.Exceptions;
using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Helpers;


namespace CleanArch.Application.Common.Models
{
	public class ErrorResponse
	{
		public string Title { get; set; }
		public string Message { get; set; }
		public int StatusCode { get; set; }
		public IEnumerable<string> Errors { get; set; }
		public string TraceId { get; set; }

		public ErrorResponse(Exception exception, string traceId)
		{
			TraceId = traceId;

			if (exception is BaseException baseException)
			{
				Title = baseException.Title;
				StatusCode = baseException.StatusCode;
				Message = baseException.Message;

				if (exception is ValidationException validationException)
				{
					Errors = validationException.Errors;
				}
			}
			else
			{
				Title = "Error Interno del Servidor";
				Message = "Ha ocurrido un error inesperado.";
				StatusCode = (int)Helpers.HttpStatusCode.InternalServerError;
			}
		}
	}
}
