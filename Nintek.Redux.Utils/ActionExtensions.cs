using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintek.Redux.Utils
{
    public static class ActionExtensions
    {
        public static bool IsActionWithPayload(this IAction action)
            => action.GetType()
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .Any(i => i.GetGenericTypeDefinition() == typeof(IAction<>));

        public static object GetPayload(this IAction action)
        {
            if (!action.IsActionWithPayload())
            {
                return null;
            }
            
            var payloadProperty = action.GetType().GetProperty("Payload");

            return payloadProperty.GetValue(action);
        }
    }
}
