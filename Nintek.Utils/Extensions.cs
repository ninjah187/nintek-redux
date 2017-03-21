using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Nintek.Utils
{
    public static class Extensions
    {
        public static void WalkOverProperties<TObj>(this TObj obj, Action<object, PropertyInfo> action)
        {
            var type = obj.GetType();
            foreach (var property in type.GetProperties())
            {
                action(obj, property);
                if (!property.PropertyType.IsPrimitiveLike())
                {
                    var value = property.GetValue(obj);
                    value.WalkOverProperties(action);
                }
            }
        }

        public static bool IsPrimitiveLike(this Type type)
            => type.IsPrimitive || type == typeof(string);
    }
}
