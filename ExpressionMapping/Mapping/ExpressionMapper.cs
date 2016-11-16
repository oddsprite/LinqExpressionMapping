using System;
using System.Linq.Expressions;

namespace ExpressionMapping.Mapping
{
    public static class ExpressionMapper
    {
        public static void PopulatePropertyAndSpecifiedField<T>(
            Expression<Func<T>> propertyExpression,
            T sourceData)
        {
            if (!(propertyExpression.Body is MemberExpression))
            {
                throw new ArgumentException("Expression body must be of type MemberExpression", nameof(propertyExpression));
            }

            var dataPropertyExpressionBody = (MemberExpression)propertyExpression.Body;
            BinaryExpression dataAssignment = Expression.Assign(dataPropertyExpressionBody, Expression.Constant(sourceData, typeof(T)));
            Expression<Action> assignData = Expression.Lambda<Action>(dataAssignment);
            assignData.Compile().Invoke();

            string propertyName = dataPropertyExpressionBody.Member.Name + "Specified";
            MemberExpression isSpecifiedField = Expression.PropertyOrField(dataPropertyExpressionBody.Expression, propertyName);
            bool fieldSpecified = sourceData != null;
            BinaryExpression fieldSpecifiedAssignment = Expression.Assign(isSpecifiedField, Expression.Constant(fieldSpecified));
            Expression<Action> assignToFieldSpecified = Expression.Lambda<Action>(fieldSpecifiedAssignment);
            assignToFieldSpecified.Compile().Invoke();
        }
    }
}
