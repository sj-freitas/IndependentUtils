using System;
using System.Linq.Expressions;
using System.Reflection;

namespace IndependentUtils.Tools
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// This metod was taken from StackOverflow:
        /// https://stackoverflow.com/questions/17115634/get-propertyinfo-of-a-parameter-passed-as-lambda-expression
        /// 
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="propertyLambda"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo<TType>(
            Expression<Func<TType, object>> propertyLambda)
        {
            if (propertyLambda == null)
            {
                throw new ArgumentNullException(nameof(propertyLambda));
            }

            MemberExpression exp = null;

            // this line is necessary, because sometimes 
            // the expression comes in as Convert(originalexpression)
            if (propertyLambda.Body is UnaryExpression unaryExpression)
            {
                if (unaryExpression.Operand is MemberExpression)
                {
                    exp = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    throw new ArgumentException(nameof(propertyLambda));
                }
            }
            else
            {
                if (propertyLambda.Body is MemberExpression)
                {
                    exp = (MemberExpression)propertyLambda.Body;
                }
                else
                {
                    throw new ArgumentException(nameof(propertyLambda));
                }
            }

            return (PropertyInfo)exp.Member;
        }
    }
}
