using System;
using System.Linq.Expressions;

namespace CombineObjectExpressions
{
    public class EmployeeService : IEmployeeService
    {
        public Employee GetById(int? id, params Expression<Func<Employee, object>>[] includeExpressions)
        {
            return new Employee();
        }

        public Employee GetById(int? id, Expression<Func<Employee, object>> includeExpressions)
        {
            return new Employee();
        }
    }
}
