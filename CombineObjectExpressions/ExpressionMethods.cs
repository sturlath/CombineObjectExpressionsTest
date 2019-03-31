using System;
using System.Linq.Expressions;

namespace CombineObjectExpressions
{
    public class ExpressionMethods
    {
        private readonly IEmployeeService service;

        public ExpressionMethods(IEmployeeService service)
        {
            this.service = service;
        }

        public ExpressionMethods() : this(new EmployeeService()) { }

        public void GetById(int? id, Expression<Func<Employee, object>> includeExpressions)
        {
            //Here Automapper mapps the expression correctly no problem.
            Expression<Func<Employee, object>> includeExpressionsMapped = AutoMapperConfig.Instance.MapToType<Expression<Func<Employee, object>>>(includeExpressions);

            //Used here but that doesn't really matter..
            service.GetById(id, includeExpressionsMapped);
        }

        public void GetById(int? id, params Expression<Func<Employee, object>>[] includeExpressions)
        {
            try
            {
                // Here is my problem. I need to be able to combine all the possible Expression params together
                // so I can pass only one combined one to Automapper like above

                // This and every other "combo try" for the params mapping has failed me.   
                Expression<Func<Employee, object>> includeExpressionsMapped = AutoMapperConfig.Instance.MapToType<Expression<Func<Employee, object>>>(includeExpressions);
            }
            catch (Exception ex)
            {
                //Fails with this error

                //Unmapped members were found. Review the types and members below.
                //Add a custom mapping expression, ignore, add a custom resolver, or modify the source / destination type
                //For no matching constructor, add a no - arg ctor, add optional arguments, or map all of the constructor parameters
                //==========================================================================================================================
                //AutoMapper created this type map for you, but your types cannot be mapped using the current configuration.
                //Expression`1[] -> Expression`1 (Destination member list)
                //System.Linq.Expressions.Expression`1[[System.Func`2[[CombineObjectExpressions.Employee, CombineObjectExpressions, 
                //Version =1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral,
                //PublicKeyToken=7cec85d7bea7798e]], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]][] 
                //-> System.Linq.Expressions.Expression`1[[System.Func`2[[CombineObjectExpressions.Employee, CombineObjectExpressions, Version=1.0.0.0,
                //Culture=neutral, PublicKeyToken=null],[System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]],
                //System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]] (Destination member list)

                //Unmapped properties:
                //Parameters
                //No available constructor.
                throw;
            }
        }
    }
}
