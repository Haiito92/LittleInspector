using System.Globalization;
using HaiitoCorp.LittleInspector.Editor.Json;
using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    #if ODIN_INSPECTOR

    public class Vector2OdinValueDrawer : VectorOdinValueDrawerBase<Vector2>
    {
        protected override GUIContent CreateLabel()
        {
            return new GUIContent("Vector 2");
        }

        protected override Vector2 DrawVectorField(GUIContent label, Vector2 value)
        {
            return EditorGUILayout.Vector2Field(label, value);
        }

        protected override void CopyVector(Vector2 value)
        {
            string clip = $"Vector2({value.x.ToString(CultureInfo.InvariantCulture)},{value.y.ToString(CultureInfo.InvariantCulture)})";
            EditorGUIUtility.systemCopyBuffer = clip;
        }

        protected override Vector2 PasteVector(Vector2 currentValue)
        {
            if(JsonParsing.TryJsonToVector2(EditorGUIUtility.systemCopyBuffer, out Vector2 outVector))
            {
                return outVector;
            }
            
            return currentValue;
        }

        protected override Vector2 ResetVector()
        {
            return Vector2.zero;
        }
    }
    
    #else
    [CustomPropertyDrawer(typeof(Vector2))]
    public class Vector2PropertyDrawer : VectorPropertyDrawerBase
    {
        protected override void DrawVectorField(SerializedProperty property)
        {
            property.vector2Value = EditorGUILayout.Vector2Field("", new Vector2(property.vector2Value.x,property.vector2Value.y));
        }

        protected override void CopyVector(SerializedProperty property)
        {
            string clip = $"Vector2({property.vector2Value.x.ToString(CultureInfo.InvariantCulture)},{property.vector2Value.y.ToString(CultureInfo.InvariantCulture)})";
            EditorGUIUtility.systemCopyBuffer = clip;
        }

        protected override void PasteVector(SerializedProperty property)
        {
            if(JsonParsing.TryJsonToVector2(EditorGUIUtility.systemCopyBuffer, out Vector2 vector))
            {
                property.vector2Value = vector;
            }
        }

        protected override void ResetVector(SerializedProperty property)
        {
            property.vector2Value = Vector2.zero;
        }
    }
    #endif
}