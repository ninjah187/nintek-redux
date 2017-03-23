using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Nintek.Redux.Core
{
    public static class UtilityExtensions
    {
        public static void WalkOverProperties<TObj>(this TObj obj, Action<object, PropertyInfo> action)
        {
            //var type = obj.GetType();
            var type = typeof(TObj);
            foreach (var property in type.GetProperties())
            {
                action(obj, property);
                if (!property.PropertyType.IsPrimitiveLike())
                {
                    var value = property.GetValue(obj);

                    if (value == null)
                    {
                        continue;
                    }

                    value.WalkOverProperties(action);
                }
            }
        }

        public static bool IsPrimitiveLike(this Type type)
            => type.IsPrimitive || type == typeof(string);
    }
}
