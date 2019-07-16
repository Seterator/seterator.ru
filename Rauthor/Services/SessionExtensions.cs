using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rauthor.Services
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            string json = JsonConvert.SerializeObject(value, type: typeof(T), settings: default);
            session.SetString(key, json);
        }
        public static T Get<T>(this ISession session, string key)
        {
            string json = session.GetString(key);
            if (json != null)
            {
                
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
