using System.Text.Json;

namespace Library_mangement_system
{
    public static class ExtenionSession
    {
        //save object in sassion
        public static void SetObject<T>(this ISession session , string key , T value)
        {
            
            string stringjson = JsonSerializer.Serialize(value);
            session.SetString(key, stringjson);
        }
        public static T? GetObject<T>(this ISession session, string key)
        {
            //
            string? stringjson = session.GetString(key);
            if (string.IsNullOrEmpty(stringjson))
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(stringjson);

        }

        public static bool Exists (this ISession session , string key)
        {
            return session.GetString(key) != null; 
        }
    }
}