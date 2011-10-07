using System;

namespace DataAccess.Infrastructure
{
	public interface ISpecification<TEntity>
		where TEntity : Entity
	{
		Func<TEntity, bool> IsSatisfied();
	}
}
