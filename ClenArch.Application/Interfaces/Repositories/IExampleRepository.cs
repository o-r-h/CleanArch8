using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;
using static Sieve.Extensions.MethodInfoExtended;


namespace CleanArch.Application.Interfaces.Repositories
{
	public interface IExampleRepository
	{

		IQueryable<ExampleModel> GetAllIQueryable();

		Task<IReadOnlyList<Example>> GetAllAsync();

		Task<IQueryable<Example>> GetPagination();

		Task<Example> GetExample(long? idExample);

		Task<Example> AddAsync(Example entity);
		Task<Example> UpdateAsync(long idExample, Example example);

		Task DeleteAsync(long id);



	}
}
