using DataAccess.Domain;
using DataAccess.Infrastructure;
using DataAccess.Repositories;
using DataAccess.Specifications;

namespace Controllers
{
	public class TopRankedPlayerController
	{
		private readonly IFoosballPlayerRepository _foosballPlayerRepository;
		private readonly IRepository<FoosballPlayer> _genericRepository;
  
		public TopRankedPlayerController(IFoosballPlayerRepository foosballPlayerRepository, IRepository<FoosballPlayer> genericRepository)
		{
			_foosballPlayerRepository = foosballPlayerRepository;
			_genericRepository = genericRepository;
		}

		public void Show(int year)
		{
			var topRankedPlayers = _foosballPlayerRepository.GetTopRankedPlayers(top: 5);
			var lousyPlayers = _genericRepository.FindAll(new LousyFoosballPlayersBornBefore(year));
		}
	}
}
