

using CleanArch.Domain.Entities;
using CleanArch.Persistence.Contexts;

namespace CleanArch.Persistence.Repositories
{
	public class ChoferRepository : RepositoryBase<Chofer>, IChoferRepository
	{
		public ChoferRepository(DbAppContext context) : base(context)
		{



		}
	}
}
