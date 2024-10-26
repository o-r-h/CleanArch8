using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.DTOs.Choferes;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Repositories;
using FluentValidation;
using Sieve.Models;
using Sieve.Services;


namespace CleanArch.Application.Services
{
    public class ChoferServices :  IChoferServices
    {
		private readonly ISieveProcessor _sieveProcessor;
		private readonly IChoferRepository choferRepository;
        protected readonly IMapper mapper;
		private readonly IValidator<ChoferDto> validator;



		public ChoferServices(ISieveProcessor sieveProcessor, 
                IChoferRepository chofeRepository, 
                IMapper mapper,
				IValidator<ChoferDto> validator)
        {
            choferRepository = chofeRepository;
			_sieveProcessor = sieveProcessor;
			this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<long> Create(ChoferDto choferDto)
        {
		 FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(choferDto);

			if (!validationResult.IsValid)
			{
				throw new FluentValidation.ValidationException(validationResult.Errors);
			}

			Chofer result = await choferRepository.AddAsync(mapper.Map<Chofer>(choferDto));
				return result.Id;
        }



        public async Task<IQueryable<ChoferDto>> GetPagination(SieveModel sieveModel)
        {
          //  IQueryable <ExampleModel> result = mapper.Map<IQueryable<Example>, IQueryable<ExampleModel>>((IQueryable<Example>) IExampleRepository.GetAllIQueryable());
            IQueryable<Chofer> result = await choferRepository.GetAllIQuerableAsync();
            IQueryable<ChoferDto> choferDtoQuery = result.ProjectTo<ChoferDto>(mapper.ConfigurationProvider);
            return _sieveProcessor.Apply(sieveModel, choferDtoQuery);
			
		}

    }
}
