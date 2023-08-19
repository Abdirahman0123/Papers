using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Papers.Extensions
{
    // This class is used to get and set item list in the session
    public static class SessionHelper
    {
        // Set the value to session using the key after serialising it.
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        //  product  is retrieved from session using the key and it is 
        // deserialised using  JsonSerializer

        // Get the items in the list from session variable using the key
        // and deserialise it
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
