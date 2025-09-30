using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.Json
{
    internal static class JsonParsing 
    {
        internal static bool TryJsonToVector2(string json, out Vector2 result)
        {
            result = Vector2.zero;
            
            if (json.StartsWith("Vector2") && TryParseVector2(json, out result))
            {
                return true;
            }
            
            if (json.StartsWith("Vector3") && TryParseVector3(json, out Vector3 outVector3))
            {
                result = outVector3;
                return true;
            }
            
            return false;
        }
        
        internal static bool TryJsonToVector3(string json, out Vector3 result)
        {
            result = Vector3.zero;

            if (json.StartsWith("Vector2") && TryParseVector2(json, out Vector2 outVector2))
            {
                result = outVector2;
                return true;
            }
            
            if (json.StartsWith("Vector3") && TryParseVector3(json, out result))
            {
                return true;
            }
            
            return false;
        }
        
        

        /// <summary>
        /// Use this when the string is supposed/known to be under the format "Vector2(x,y)"
        /// </summary>
        private static bool TryParseVector2(string json, out Vector2 vector)
        {
            vector = Vector2.zero;
            
            string[] parts = json.Substring("Vector2".Length).Trim('(',')').Split(',');

            if (parts.Length != 2) return false;

            if (!float.TryParse(parts[0], out float x)) return false;
            if (!float.TryParse(parts[1], out float y)) return false;

            vector = new Vector2(x, y);
            return true;
        }
        
        /// <summary>
        /// Use this when the string is supposed/known to be under the format "Vector3(x,y,z)"
        /// </summary>
        private static bool TryParseVector3(string json, out Vector3 vector)
        {
            vector = Vector3.zero;
            
            string[] parts = json.Substring("Vector3".Length).Trim('(',')').Split(',');

            if (parts.Length != 3) return false;

            if (!float.TryParse(parts[0], out float x)) return false;
            if (!float.TryParse(parts[1], out float y)) return false;
            if (!float.TryParse(parts[2], out float z)) return false;

            vector = new Vector3(x, y, z);
            return true;
        }
    }
}