using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DomainModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public class DbSet<TEntity> : DbQuery<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable where TEntity : AggregateRoot
    {
        protected List<TEntity> items;

        public virtual ObservableCollection<TEntity> Local { get; }

        public DbSet()
        {
            items = new List<TEntity>();

            Local = new ObservableCollection<TEntity>(items);

            //relatedItems = 
        }

        public TEntity Find(Guid id)
        {
            var item = items.FirstOrDefault(s => s.Id == id);

            return item;
        }

        protected override IQueryable<TEntity> GetResults()
        {
            throw new NotImplementedException();

            //return items.AsQueryable();
        }

        public override IEnumerator<TEntity> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }


        public virtual void Add(TEntity entity)
        {
            items.Add(entity);
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            items.AddRange(entities);

            return entities;
        }

        public virtual void Remove(TEntity entity)
        {
            items.Remove(entity);
        }

        public virtual IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            //items.RemoveRange(entities);

            return entities;
        }
    }
}
