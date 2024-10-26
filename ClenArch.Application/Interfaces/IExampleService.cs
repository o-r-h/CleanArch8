

using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;
using Sieve.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IExampleService 
    {
       

        Task<long> CreateAsync(ExampleModel exampleModel);

		Task<ExampleModel> UpdateAsync(long id, ExampleModel exampleModel);


	//	Task DeleteAsync(long idExample);

		Task DeleteByIdAsync(long idExample);

		Task<Example> GetExample(long? idExample);

		IEnumerable<ExampleModel> GetAll();

		IQueryable<ExampleModel> GetPagination(SieveModel sieveModel);

		//Task<Byte[]> DownloadFile();

	}
}
