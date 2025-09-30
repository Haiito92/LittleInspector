using HaiitoCorp.LittleInspector.Editor.Json;
using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
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
}
