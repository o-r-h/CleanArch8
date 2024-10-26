
using CleanArch.Domain.DTOs.Choferes;

namespace CleanArch.Application.Interfaces
{
	public interface IChoferServices
	{
		Task<long> Create(ChoferDto choferDto);
		//Task<IQueryable<ChoferDto>> GetPagination(SieveModel sieveModel);
	}
}