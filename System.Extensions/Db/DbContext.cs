using System;
using System.Collections.Generic;
using System.DomainModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public abstract class DbContext : IDisposable
    {
        private readonly IDictionary<Type, object> sets;

        public DbContext()
        {
            sets = new Dictionary<Type, object>();

            var properties = GetType().GetRuntimeProperties().Where(p => p.PropertyType.FullName.Contains(typeof(DbSet<>).FullName));

            foreach (var property in properties)
            {
                var set = Activator.CreateInstance(property.PropertyType);

                property.SetValue(this, set);

                sets.Add(property.PropertyType.GenericTypeArguments[0], set);
            }
        }

        public virtual DbSet<TEntity> Set<TEntity>() where TEntity : AggregateRoot
        {
            var type = typeof(TEntity);

            var set = sets[type] as DbSet<TEntity>;

            return set;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            foreach (var set in sets)
            {
                var type = set.Key;

                //var _set = set.Value as DbSet<>;
            }

            return await Task.FromResult(0);
        }

        public void Dispose()
        {

        }
    }
}
