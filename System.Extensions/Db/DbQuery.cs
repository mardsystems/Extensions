using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public class DbQuery<TResult> : IOrderedQueryable<TResult>, IQueryable<TResult>, IEnumerable<TResult>, IOrderedQueryable, IQueryable, IEnumerable
    {
        public DbQuery()
        {
            Provider = new DbQueryProvider<TResult>(GetResults);

            Expression = Expression.Constant(this);
        }

        protected virtual IQueryable<TResult> GetResults()
        {
            throw new NotImplementedException();
        }

        internal DbQuery(IQueryProvider provider, Expression expression)
        {
            Provider = provider;

            Expression = expression;
        }

        public virtual IEnumerator<TResult> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<TResult>>(Expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(TResult); }
        }

        public Expression Expression { get; private set; }

        public IQueryProvider Provider { get; private set; }
    }
}
