using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IndependentUtils.Tools.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<T> GetAllImplementationsOf<T>(
            this Assembly assembly, 
            Func<Type, object> typeResolver = null)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }
            if (!typeof(T).IsInterface)
            {
                throw new InvalidOperationException(
                    $"Type {typeof(T).FullName} must be an interface type.");
            }

            typeResolver = typeResolver == null? 
                type =>
                {
                    if (!type.GetConstructors().Any(t => t.GetParameters().Length == 0))
                    {
                        return null;
                    }
                    return Activator.CreateInstance(type);
                }
                : typeResolver;

            return assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(currInterface => currInterface == typeof(T)))
                .Select(typeResolver)
                .Where(t => t != null)
                .Cast<T>();
        }
    }
}
