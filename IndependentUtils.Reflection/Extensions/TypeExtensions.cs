using System;

namespace IndependentUtils.Reflection.Extensions
{
    public static class TypeExtensions
    {
        public static TType CreateInstance<TType>(this Type type, params object[] constructorParameters)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (type.GetType().IsAssignableFrom(typeof(TType)))
            {
                throw new ArgumentException($"Type {type.Name} is not a {nameof(TType)}.", nameof(type));
            }

            return (TType) Activator.CreateInstance(type, constructorParameters);
        }
    }
}
