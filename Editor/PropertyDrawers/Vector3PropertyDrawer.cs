using System.Globalization;
using HaiitoCorp.LittleInspector.Editor.Json;
using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    #if ODIN_INSPECTOR
    public class Vector3OdinValueDrawer : VectorOdinValueDrawerBase<Vector3>
    {
        protected override GUIContent CreateLabel()
        {
            return new GUIContent("Vector 3");
        }

        protected override Vector3 DrawVectorField(GUIContent label, Vector3 value)
        {
            return EditorGUILayout.Vector3Field(label, value);
        }

        protected override void CopyVector(Vector3 value)
        {
            Debug.LogWarning(value.x);
            string clip = $"Vector3({value.x.ToString(CultureInfo.InvariantCulture)},{value.y.ToString(CultureInfo.InvariantCulture)},{value.z.ToString(CultureInfo.InvariantCulture)})";
            
            Debug.LogWarning(clip);
            EditorGUIUtility.systemCopyBuffer = clip;
        }

        protected override Vector3 PasteVector(Vector3 currentValue)
        {
            if(JsonParsing.TryJsonToVector3(EditorGUIUtility.systemCopyBuffer, out Vector3 outVector))
            {
                return outVector;
            }
            
            return currentValue;
        }

        protected override Vector3 ResetVector()
        {
            return Vector3.zero;
        }
    }
    
    #else
    [CustomPropertyDrawer(typeof(Vector3))]
    public class Vector3PropertyDrawer : VectorPropertyDrawerBase
    {
        protected override void DrawVectorField(SerializedProperty property)
        {
            property.vector3Value = EditorGUILayout.Vector3Field("", new Vector3(property.vector3Value.x,property.vector3Value.y, property.vector3Value.z));
        }

        protected override void CopyVector(SerializedProperty property)
        {
            string clip = $"Vector3({property.vector3Value.x.ToString(CultureInfo.InvariantCulture)},{property.vector3Value.y.ToString(CultureInfo.InvariantCulture)},{property.vector3Value.z.ToString(CultureInfo.InvariantCulture)})";
            EditorGUIUtility.systemCopyBuffer = clip;
        }

        protected override void PasteVector(SerializedProperty property)
        {
            if(JsonParsing.TryJsonToVector3(EditorGUIUtility.systemCopyBuffer, out Vector3 vector))
            {
                property.vector3Value = vector;
            }
        }

        protected override void ResetVector(SerializedProperty property)
        {
            property.vector3Value = Vector3.zero;
        }
    }
    #endif
}
