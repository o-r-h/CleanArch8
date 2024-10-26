using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Entities;
using Sieve.Models;
using Sieve.Services;

namespace CleanArch.Application.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository exampleRepository;
		private readonly IAsyncRepository<Example> asyncRepository;
		protected readonly IMapper mapper;
        private readonly ISieveProcessor sieveProcessor;

		public ExampleService(IExampleRepository exampleRepository, IAsyncRepository<Example> asyncRepository, IMapper mapper, ISieveProcessor sieveProcessor)
		{
			this.exampleRepository = exampleRepository;
			this.asyncRepository = asyncRepository;
			this.mapper = mapper;
			this.sieveProcessor = sieveProcessor;
		}


		public async Task<long> CreateAsync(ExampleModel exampleModel)
		{
		//	new ExampleValidator(exampleModel).ValidateAndThrowCustomException(exampleModel);
		
			var result = await exampleRepository.AddAsync(mapper.Map<Example>(exampleModel));
			return result.Id;

		}

		public async Task<ExampleModel> UpdateAsync(long id, ExampleModel exampleModel)
		{
		    //new ExampleValidator(exampleModel).ValidateAndThrowCustomException(exampleModel);
			var result = await exampleRepository.UpdateAsync(id, mapper.Map<Example>(exampleModel));
			return  mapper.Map<ExampleModel>(result); 
		}



		public async Task<Example> GetExample(long? idExample)
		{

			var result = await exampleRepository.GetExample(idExample);

			return result; 
		}

		public IEnumerable<ExampleModel> GetAll()
		{
			
			return exampleRepository.GetAllIQueryable();
		}


		//public async Task DeleteAsync(long idExample)
		//{

		//	var example = await exampleRepository.GetExample(idExample);

		//	await exampleRepository.DeleteAsync(idExample);
		//}

		public async Task DeleteByIdAsync(long idExample)
		{
			await asyncRepository.DeleteByIdAsync(idExample);
		}

		//public async Task<Byte[]> DownloadFile()
		//{
		//	var result = await exampleRepository.GetAll();
		//	return CsvExport<Example>.WriteCsvToMemory(result, ";", System.Text.Encoding.UTF8);
		//}


		public IQueryable<ExampleModel> GetPagination(SieveModel sieveModel)
        {
          
           IQueryable<ExampleModel> result = exampleRepository.GetAllIQueryable();
            return sieveProcessor.Apply(sieveModel, result);
        }



    }
}
