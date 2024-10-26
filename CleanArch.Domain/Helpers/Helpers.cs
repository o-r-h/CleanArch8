using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Helpers
{
	public static class Helpers
	{
		public  enum HttpStatusCode
		{
			// 2XX - Éxito
			Ok = 200,
			Created = 201,
			Accepted = 202,
			NoContent = 204,

			// 4XX - Errores del Cliente
			BadRequest = 400,
			Unauthorized = 401,
			Forbidden = 403,
			NotFound = 404,
			MethodNotAllowed = 405,
			Conflict = 409,
			UnsupportedMediaType = 415,
			UnprocessableEntity = 422,
			TooManyRequests = 429,

			// 5XX - Errores del Servidor
			InternalServerError = 500,
			NotImplemented = 501,
			BadGateway = 502,
			ServiceUnavailable = 503,
			GatewayTimeout = 504
		}

	}
}
