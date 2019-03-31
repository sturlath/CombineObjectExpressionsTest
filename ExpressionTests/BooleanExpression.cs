using CombineObjectExpressions;
using CombineObjectExpressions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Linq.Expressions;

namespace ExpressionTests
{
    [TestClass]
    public class BooleanExpression
    {
        /// <summary>
        /// This works great
        /// </summary>
        [TestMethod]
        public void CombineTwoBoolianExpressions()
        {
            Expression<Func<Employee, bool>> filter1 = p => p.Name == "John Doe";
            Expression<Func<Employee, bool>> filter2 = p => p.Address == "Address 123";

            // Two boolean expressions combined
            Expression<Func<Employee, bool>> filterCombined = filter1.And(filter2);

            filterCombined.Body.ToString().ShouldBe("((p.Name == \"John Doe\") And (p.Address == \"Address 123\"))");
        }

        /// <summary>
        /// Can't get this one to work
        /// </summary>
        [TestMethod]
        public void CombineTwoObjectExpressions()
        {
            Expression<Func<Employee, object>> filter1 = p => p.Info;
            Expression<Func<Employee, object>> filter2 = p => p.Profile;

            // Trying to combine two object expressions fails
            Expression<Func<Employee, object>> filterCombined = ParameterToMemberExpressionRebinder.CombinePropertySelectorWithPredicate(filter1, filter2);


            filterCombined.Body.ToString().ShouldBe("((p => p.Info And p => p.Profile))"); //Something like this anyway...
        }


        [TestMethod]
        public void AutoMapperTestCaseThatWorks()
        {
            var expressionMethods = new ExpressionMethods();

            expressionMethods.GetById(1, x => x.Info);
        }

        [TestMethod]
        public void AutoMapperTestCaseThatFails()
        {
            var expressionMethods = new ExpressionMethods();

            expressionMethods.GetById(1, x => x.Info, x => x.Profile);
        }
    }
}
