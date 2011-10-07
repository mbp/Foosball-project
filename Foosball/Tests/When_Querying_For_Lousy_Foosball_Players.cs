using System;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Domain;
using Mvno.TestHelpers;
using DataAccess.Infrastructure;
using DataAccess.Specifications;
using Xunit;

namespace Tests
{
	public class When_Querying_For_Lousy_Foosball_Players : BehaviorTesting<Repository<FoosballPlayer>>
	{
		private const string StefanAniff = "Stefan Aniff";
		private const int Rank = 1000;

		public IEnumerable<FoosballPlayer> Result { get; private set; }

		protected override void Given()
		{
			var lousyFoosballPlayer = new FoosballPlayer
			{
				Id = Guid.NewGuid(),
				Name = StefanAniff,
				Born = new DateTime(1985, 9, 12),
				Rank = Rank
			};
			ClassUnderTest.Add(lousyFoosballPlayer);

			var bestFoosballPlayer = new FoosballPlayer
			{
				Id = Guid.NewGuid(),
				Name = "Frederic Collignon",
				Born = new DateTime(1980, 2, 15),
				Rank = 1
			};
			ClassUnderTest.Add(bestFoosballPlayer);
		}

		protected override void When()
		{
			Result = ClassUnderTest.FindAll(new LousyFoosballPlayersBornBefore(1990)).ToList();
		}

		[Then]
		public void There_Should_Only_Be_One_Lousy_Player()
		{
			Assert.Equal(1, Result.Count());
		}

		[Then]
		public void The_Lousy_Players_Name_Is_Stefan_Aniff()
		{
			Assert.Equal(StefanAniff, Result.First().Name);
		}

		[Then]
		public void The_Lousy_Players_Rank_Is_1000()
		{
			Assert.Equal(1000, Result.First().Rank);
		}
	}
}
