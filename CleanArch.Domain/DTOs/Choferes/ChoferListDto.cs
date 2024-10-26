using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.DTOs.Choferes
{
	public class ChoferListDto
	{
		public int Id { get; set; }

		public string Nombre { get; set; } = string.Empty;
		public string ApellidoPaterno { get; set; } = string.Empty;
		public string ApellidoMaterno { get; set; } = string.Empty;
		public string NombreDocumento { get; set; } = string.Empty;
		public string NumeroDocumento { get; set; } = string.Empty;
		public string Brevete { get; set; } = string.Empty;

		public string NombreCompleto()
		{
			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(string.Format("{0}, {1} {2}", this.Nombre, this.ApellidoPaterno, this.ApellidoMaterno));
		}
	}
}
