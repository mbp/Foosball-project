using System;

namespace DataAccess.Infrastructure
{
	public abstract class Entity
	{
		public Guid Id
		{
			get;
			set;
		}
	}
}
