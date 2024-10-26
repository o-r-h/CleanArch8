using CleanArch.Domain.Common;

namespace CleanArch.Domain.Entities
{
	public class Chofer :BaseEntity
	{
		
		public string Nombre { get; set; } = string.Empty;
		public string ApellidoPaterno { get; set; } = string.Empty;
		public string ApellidoMaterno { get; set; } = string.Empty;
		public int TipoDocumento { get; set; }
		public string NumeroDocumento { get; set; } = string.Empty;
		public string Brevete { get; set; } = string.Empty;


	}
}
