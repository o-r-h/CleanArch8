using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;
using System.Data.Entity;

namespace CleanArch.Persistence.Repositories
{
	public class ExampleRepository : RepositoryBase<Example> ,IExampleRepository
	{

		private DbAppContext context;
		public ExampleRepository(DbAppContext context) : base(context)
		{
			this.context = context;
		}



		public IQueryable<ExampleModel> GetAllIQueryable()
		{

			var query = from r in context.Examples
						select new ExampleModel
						{
							CreatedAt = r.CreatedAt,
							CreatedBy = r.CreatedBy,
							IdExample = r.Id,
							ModifiedAt = r.ModifiedAt,
							ModifiedBy = r.ModifiedBy,
							PriceExample = r.PriceExample,
							NameExample = r.NameExample
						};
			return query;
		}


		public async Task DeleteAsync(long idExample)
		{
			context.Set<Example>().Remove(await GetByIdAsync(idExample));
			await context.SaveChangesAsync();
		}


		
		public async Task<Example> GetExample(long? idExample)
		{

			Example exampleRecord = await context.Set<Example>().FindAsync(idExample);
			
			return exampleRecord;
		}

		public async Task<Example> UpdateAsync(long idExample, Example example)
		{
			Example exampleRecord = await context.Set<Example>().FindAsync(idExample);
			if (exampleRecord == null)
			{
				return exampleRecord = new Example();
			}
				exampleRecord.NameExample = example.NameExample;
				
				exampleRecord.ModifiedBy = example.ModifiedBy;
				exampleRecord.ModifiedAt = System.DateTime.Now;
				exampleRecord.PriceExample = example.PriceExample;

				context.Entry(exampleRecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				await context.SaveChangesAsync();
				return exampleRecord;
			
		}


		public async Task<IQueryable<Example>> GetPagination()
		{
			return await Task.Run(() => context.Set<Example>().AsQueryable().AsNoTracking());
		}

		
	}
}
