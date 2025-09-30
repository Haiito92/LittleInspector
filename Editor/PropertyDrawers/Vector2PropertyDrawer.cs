using System;
using HaiitoCorp.LittleInspector.Editor.Json;
using Unity.Plastic.Newtonsoft.Json;
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
            if (GUILayout.Button("C"))
            {
                CopyVector2(property); 
            }
            
            if (GUILayout.Button("P"))
            {
                PasteVector2(property);
            }
            
            if (GUILayout.Button("R"))
            {
                ResetVector2(property);
            }
            EditorGUILayout.EndHorizontal();
            
            property.vector2Value = EditorGUILayout.Vector2Field("", new Vector2(property.vector2Value.x,property.vector2Value.y));
            
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