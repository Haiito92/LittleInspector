using HaiitoCorp.LittleInspector.Editor.Json;
using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(Vector2))]
    public class Vector2PropertyDrawer : VectorPropertyDrawerBase
    {
        protected override void DrawVectorField(SerializedProperty property)
        {
            property.vector2Value = EditorGUILayout.Vector2Field("", new Vector2(property.vector2Value.x,property.vector2Value.y));
        }

        protected override void CopyVector(SerializedProperty property)
        {
            string clip = $"Vector2({property.vector2Value.x},{property.vector2Value.y})";
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
}