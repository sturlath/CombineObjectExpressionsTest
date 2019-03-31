using System;
using System.Linq.Expressions;

namespace CombineObjectExpressions
{
    public interface IGenericService<T>
    {
        T GetById(int? id, params Expression<Func<T, object>>[] includeExpressions);

        T GetById(int? id, Expression<Func<T, object>> includeExpressions);
    }
}
