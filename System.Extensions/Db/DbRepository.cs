using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public abstract class DbRepository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : AggregateRoot
    {
        protected readonly TContext context;

        protected DbRepository()
        {

        }

        protected DbRepository(TContext context)
        {
            this.context = context;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await InitializeAsync();

            context.Set<TEntity>().Add(entity);

            //await Task.FromResult(true);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await InitializeAsync();

            //var _item = items.Where((TEntity arg) => arg.Id == entity.Id).FirstOrDefault();
            //items.Remove(_item);
            //items.Add(entity);

            //await Task.FromResult(true);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            await InitializeAsync();

            //var _item = items.Where((TEntity arg) => arg.Id == entity.Id).FirstOrDefault();
            //items.Remove(_item);

            //return await Task.FromResult(true);
        }

        protected abstract Task InitializeAsync();
    }
}
