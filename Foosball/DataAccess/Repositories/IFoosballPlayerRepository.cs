using System.Collections.Generic;
using DataAccess.Domain;
using DataAccess.Infrastructure;

namespace DataAccess.Repositories
{
	public interface IFoosballPlayerRepository : IRepository<FoosballPlayer>
	{
		IEnumerable<FoosballPlayer> GetTopRankedPlayers(int top);
	}
}
