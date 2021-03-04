using System.Text.Json;

namespace TaTava.Extensions
{
    public static class ObjectSerializerExtensions
    {
        #region - Serializes

        public static string Serialize<TEntity>(this TEntity entity) where TEntity : class
        {
            return JsonSerializer.Serialize(entity);
        }

        #endregion

        #region - Deserializes

        public static TEntity Deserialize<TEntity>(this string serializedObject)
        {

            var returnObject = JsonSerializer.Deserialize<TEntity>(serializedObject);
            return returnObject;
        }

        #endregion


    }
}
