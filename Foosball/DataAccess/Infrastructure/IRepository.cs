using System;
using System.Collections.Generic;

namespace DataAccess.Infrastructure
{
	public interface IRepository<TEntity>
			where TEntity : Entity
	{
		TEntity GetById(Guid id);
		void Add(TEntity entity);
		void Remove(TEntity entity);
		IEnumerable<TEntity> FindAll(ISpecification<TEntity> specification);
	}
}
