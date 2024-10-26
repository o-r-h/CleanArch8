using CleanArch.Domain.Common;
using System.Linq.Expressions;

namespace CleanArch.Application.Interfaces.Repositories
{
	public interface IAsyncRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();

		Task<IQueryable<T>> GetAllIQuerableAsync();

		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
									   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
									   string includeString = null,
									   bool disableTracking = true);

		Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
									   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
									   List<Expression<Func<T, object>>> includes = null,
									   bool disableTracking = true);


		Task<T> GetByIdAsync(long id);

		Task<T> AddAsync(T entity);

		Task<T> UpdateAsync(T entity);

		Task DeleteAsync(T entity);

		Task<int> DeleteByIdAsync(long id);


		void AddEntity(T entity);

		void UpdateEntity(T entity);

		void DeleteEntity(T entity);
	}
}