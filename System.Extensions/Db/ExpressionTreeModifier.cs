using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    internal class ExpressionTreeModifier<TResult> : ExpressionVisitor
    {
        private IQueryable<TResult> results;

        internal ExpressionTreeModifier(IQueryable<TResult> places)
        {
            this.results = places;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c.Value is DbQuery<TResult>)
            {
                return Expression.Constant(this.results);
            }
            else
            {
                return c;
            }
        }
    }
}
