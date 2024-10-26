using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Common.Exceptions
{
	public class ValidationException : BaseException
	{
		public IEnumerable<string> Errors { get; }

		public ValidationException(IEnumerable<string> errors)
			: base("Error de validación en la aplicación", "Error de Validación", (int)Helpers.HttpStatusCode.BadRequest)
		{
			Errors = errors;
		}
	}

	public class ApplicationException : BaseException
	{
		public ApplicationException(string message)
			: base(message, "Error de Aplicación", (int)Helpers.HttpStatusCode.BadRequest)
		{
		}
	}
}
