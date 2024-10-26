using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Helpers;


namespace CleanArch.Infrastructure.Exceptions
{
	public class ExternalApiException : BaseException
	{
		public ExternalApiException(string message)
			: base(message, "Error en API Externa", (int)Helpers.HttpStatusCode.BadGateway)
		{
		}
	}

	public class IntegrationException : BaseException
	{
		public IntegrationException(string message)
			: base(message, "Error de Integración", (int)Helpers.HttpStatusCode.InternalServerError)
		{
		}
	}
}
