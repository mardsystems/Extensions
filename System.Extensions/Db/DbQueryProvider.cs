using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public class DbQueryProvider<TResult> : IQueryProvider
    {
        //private readonly string root;

        private readonly Func<IQueryable<TResult>> getResults;

        public DbQueryProvider(Func<IQueryable<TResult>> getResults) //string root
        {
            //this.root = root;

            this.getResults = getResults;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new DbQuery<TResult>(this, expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return (IQueryable<TElement>)new DbQuery<TResult>(this, expression);
        }

        public object Execute(Expression expression)
        {
            return Execute<DbQuery<TResult>>(expression);
        }

        public TResults Execute<TResults>(Expression expression) //
        {
            var isEnumerable = (typeof(TResults).Name == "IEnumerable`1");

            var results = getResults();

            var result = DbQueryContext<TResult>.Execute(expression, isEnumerable, results); //root

            return (TResults)result;
        }
    }
}
