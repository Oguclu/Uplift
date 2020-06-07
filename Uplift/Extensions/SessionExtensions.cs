using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uplift.Extensions
{
    public static class SessionExtensions
    {
        public static void setObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T getObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
        }
    }
}
