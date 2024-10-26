using CleanArch.Domain.Exceptions;
using CleanArch.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Exceptions
{
	public class DatabaseException : BaseException
	{
		public DatabaseException(string message)
			: base(message, "Error de Base de Datos", (int)Helpers.HttpStatusCode.BadGateway)
		{
		}
	}

	public class ConcurrencyException : BaseException
	{
		public ConcurrencyException(string message)
			: base(message, "Error de Concurrencia", (int)Helpers.HttpStatusCode.Conflict)
		{
		}
	}
}
