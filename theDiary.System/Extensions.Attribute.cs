using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System
{
    public static partial class SystemExtensions
    {
        public static bool ImplementsInterface<T>(this Type type)
        {
            Type interfaceType = typeof(T);

            if (!interfaceType.IsInterface)
                throw new InvalidOperationException("The type specified is not an interface type.");

            Type[] interfaces = type.FindInterfaces(new TypeFilter((a, b) => a == interfaceType), null);

            return (interfaces != null && interfaces.Length != 0);
        }

        private static bool HasInteraceCheck(Type typeObj, object criteria)
        {
            return typeObj.Equals(criteria);
        }

        public static bool HasAttribute<T>(this ICustomAttributeProvider attributeProvider)
                where T : Attribute
        {
            return attributeProvider.HasAttribute<T>(true);
        }

        public static bool HasAttribute<T>(this ICustomAttributeProvider attributeProvider, bool inherited)
            where T : Attribute
        {
            object[] attributes = attributeProvider.GetCustomAttributes(typeof(T), inherited);
            return (attributes != null && attributes.Length > 0);
        }

        public static T GetAttribute<T>(this ICustomAttributeProvider attributeProvider)
            where T : Attribute
        {
            return attributeProvider.GetAttribute<T>(false);
        }

        public static T GetAttribute<T>(this ICustomAttributeProvider attributeProvider, bool inherited)
            where T : Attribute
        {
            return attributeProvider.GetAttributes<T>(inherited).FirstOrDefault();
        }
        
        public static IEnumerable<T> GetAttributes<T>(this ICustomAttributeProvider attributeProvider)
            where T : Attribute
        {
            return attributeProvider.GetAttributes<T>(true);
        }

        public static IEnumerable<T> GetAttributes<T>(this ICustomAttributeProvider attributeProvider, bool inherited)
            where T : Attribute
        {
            return attributeProvider.GetCustomAttributes(typeof(T), inherited).Cast<T>();
        }

        public static IEnumerable<T> GetAttributes<T>(this ICustomAttributeProvider attributeProvider, Predicate<T> predicate)
            where T: Attribute
        {
            return attributeProvider.GetAttributes<T>().Where(attribute=>predicate(attribute));
        }
    }
}
