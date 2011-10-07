using System;
using DataAccess.Domain;
using DataAccess.Infrastructure;

namespace DataAccess.Specifications
{
	public class LousyFoosballPlayersBornBefore : ISpecification<FoosballPlayer>
	{
		private readonly int _year;

		public LousyFoosballPlayersBornBefore(int year)
		{
			_year = year;
		}

		public Func<FoosballPlayer, bool> IsSatisfied()
		{
			return player => player.Rank > 500
				&& player.Born < new DateTime(_year, 1, 1);
		}
	}
}
