using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Infrastructure
{
	public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : Entity
	{
		public IList<TEntity> Session { get; private set; }

		public Repository()
		{
			Session = new List<TEntity>();
		}

		public TEntity GetById(Guid id)
		{
			return Session.SingleOrDefault(x => x.Id == id);
		}

		public void Add(TEntity entity)
		{
			Session.Add(entity);
		}

		public void Remove(TEntity entity)
		{
			Session.Remove(entity);
		}

		public IEnumerable<TEntity> FindAll(ISpecification<TEntity> specification)
		{
			return Session.Where(specification.IsSatisfied());
		}
	}
}