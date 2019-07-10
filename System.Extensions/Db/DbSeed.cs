using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public static class DbSeed
    {
        public static void AddOrUpdate<TEntity>(this DbSet<TEntity> dbSet, Func<TEntity, Guid> p1, params TEntity[] entities) where TEntity : AggregateRoot
        {
            foreach (var entity in entities)
            {
                dbSet.Add(entity);
            }
        }
    }
}
