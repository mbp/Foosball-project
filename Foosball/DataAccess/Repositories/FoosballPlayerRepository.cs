using System.Linq;
using DataAccess.Domain;
using DataAccess.Infrastructure;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class FoosballPlayerRepository : Repository<FoosballPlayer>, IFoosballPlayerRepository
	{
		public IEnumerable<FoosballPlayer> GetTopRankedPlayers(int top)
		{
			return Session.OrderBy(x => x.Rank).Take(top);
		}
	}
}
