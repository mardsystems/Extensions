using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public interface IQueryContext
    {
        object Execute(Expression expression, bool isEnumerable);
    }
}
