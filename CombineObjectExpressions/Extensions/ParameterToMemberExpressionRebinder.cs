using System;
using System.Linq.Expressions;

namespace CombineObjectExpressions.Extensions
{
    // Class based on this answer https://stackoverflow.com/a/1132073/1187583
    public class ParameterToMemberExpressionRebinder : ExpressionVisitor
    {
        private readonly ParameterExpression _paramExpr;
        private readonly MemberExpression _memberExpr;

        private ParameterToMemberExpressionRebinder(ParameterExpression paramExpr, MemberExpression memberExpr)
        {
            _paramExpr = paramExpr;
            _memberExpr = memberExpr;
        }

        public override Expression Visit(Expression p)
        {
            return base.Visit(p == _paramExpr ? _memberExpr : p);
        }

        public static Expression<Func<T, T2>> CombinePropertySelectorWithPredicate<T, T2>(
            Expression<Func<T, T2>> propertySelector,
            Expression<Func<T, T2>> propertyPredicate)
        {
            var memberExpression = propertySelector.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new ArgumentException("propertySelector");
            }

            var expr = Expression.Lambda<Func<T, T2>>(propertyPredicate.Body, propertySelector.Parameters);
            var rebinder = new ParameterToMemberExpressionRebinder(propertyPredicate.Parameters[0], memberExpression);
            expr = (Expression<Func<T, T2>>)rebinder.Visit(expr);

            return expr;
        }
    }
}