using System;
using DataAccess.Infrastructure;

namespace DataAccess.Domain
{
	public class FoosballPlayer : Entity
	{
		public string Name { get; set; }
		public int Rank { get; set; }
		public DateTime Born { get; set; }
	}
}
