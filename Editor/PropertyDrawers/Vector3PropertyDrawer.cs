using HaiitoCorp.LittleInspector.Editor.Json;
using Sirenix.OdinInspector.Editor;
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
            return EditorGUILayout.Vector2Field(label, value);
        }

        protected override void CopyVector(Vector3 value)
        {
            string clip = $"Vector3({value.x},{value.y},{value.z})";
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
            string clip = $"Vector3({property.vector3Value.x},{property.vector3Value.y},{property.vector3Value.z})";
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
