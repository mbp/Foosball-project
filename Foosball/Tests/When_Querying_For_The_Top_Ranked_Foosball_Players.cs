using System;
using System.Linq;
using DataAccess.Repositories;
using Mvno.TestHelpers;
using DataAccess.Domain;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
	public class When_Querying_For_The_Top_Ranked_Foosball_Players : BehaviorTesting<FoosballPlayerRepository>
	{
		public IEnumerable<FoosballPlayer> Result { get; private set; }

		protected override void Given()
		{
			for (int i = 1; i <= 20; i++)
			{
				var foosballPlayer = new FoosballPlayer
				{
					Id = Guid.NewGuid(),
					Name = "Player " + i,
					Born = DateTime.Now.AddYears(-30),
					Rank = i
				};

				ClassUnderTest.Add(foosballPlayer);
			}
		}

		protected override void When()
		{
			Result = ClassUnderTest.GetTopRankedPlayers(top: 5);
		}

		[Then]
		public void The_Count_Should_Be_Five()
		{
			Assert.Equal(5, Result.Count());
		}

		[Then]
		public void The_First_Should_Have_The_Best_Rank()
		{
			Assert.Equal(1, Result.First().Rank);
		}

		[Then]
		public void The_Last_Should_Have_The_Worst_Rank()
		{
			Assert.Equal(5, Result.Last().Rank);
		}
	}
}