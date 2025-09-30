using HaiitoCorp.LittleInspector.Editor.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(Vector2))]
    public class Vector2PropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(label);
            property.vector2Value = EditorGUILayout.Vector2Field("", new Vector2(property.vector2Value.x,property.vector2Value.y));
            
            if (GUILayout.Button("C", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                CopyVector2(property); 
            }
            
            if (GUILayout.Button("P", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                PasteVector2(property);
            }
            
            if (GUILayout.Button("R", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                ResetVector2(property);
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space(5);
        }

        private void CopyVector2(SerializedProperty property)
        {
            string clip = $"Vector2({property.vector2Value.x},{property.vector2Value.y})";
            EditorGUIUtility.systemCopyBuffer = clip;
        }
        
        private void PasteVector2(SerializedProperty property)
        {
            if(JsonParsing.TryJsonToVector2(EditorGUIUtility.systemCopyBuffer, out Vector2 vector))
            {
                property.vector2Value = vector;
            }
        }
        
        private void ResetVector2(SerializedProperty property)
        {
            property.vector2Value = Vector2.zero;
        }  
    }
}