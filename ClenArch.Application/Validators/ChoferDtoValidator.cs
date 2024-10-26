

using CleanArch.Domain.DTOs.Choferes;
using FluentValidation;

namespace CleanArch.Application.Validators
{
	public class ChoferDtoValidator : AbstractValidator<ChoferDto>
	{
		public ChoferDtoValidator()
		{
			RuleFor(x => x.Nombre)
				.NotEmpty().WithMessage("El nombre es requerido")
				.MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

			RuleFor(x => x.Brevete)
				.NotEmpty().WithMessage("El número de brevete es requerido")
				.Matches(@"^[A-Z0-9]+$").WithMessage("el brevete solo puede contener letras mayúsculas y números");

		}
	}
}
