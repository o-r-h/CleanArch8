

namespace CleanArch.Domain.Exceptions
{
	public class DomainValidationException : BaseException
	{
		public IEnumerable<string> Errors { get; }

		public DomainValidationException(IEnumerable<string> errors)
			: base("Error en las reglas de dominio", "Error de Dominio",(int)Helpers.Helpers.HttpStatusCode.BadRequest)
		{
			Errors = errors;
		}
	}

	public class EntityNotFoundException : BaseException
	{
		public EntityNotFoundException(string message)
			: base(message, "Entidad no encontrada", (int)Helpers.Helpers.HttpStatusCode.NotFound)
		{
		}
	}


}
