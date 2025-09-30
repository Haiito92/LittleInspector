using System;
using HaiitoCorp.LittleInspector.Editor.Json;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(Vector3))]
    public class Vector3PropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(label);
            property.vector3Value = EditorGUILayout.Vector3Field("", new Vector3(property.vector3Value.x,property.vector3Value.y, property.vector3Value.z));

            if (GUILayout.Button("C", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                CopyVector3(property); 
            }
            
            if (GUILayout.Button("P", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                PasteVector3(property);
            }
            
            if (GUILayout.Button("R", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                ResetVector3(property);
            }
            EditorGUILayout.EndHorizontal();
            
            
            EditorGUILayout.Space(5);
        }

        private void CopyVector3(SerializedProperty property)
        {
            string clip = $"Vector3({property.vector3Value.x},{property.vector3Value.y},{property.vector3Value.z})";
            EditorGUIUtility.systemCopyBuffer = clip;
        }
        
        private void PasteVector3(SerializedProperty property)
        {
            if(JsonParsing.TryJsonToVector3(EditorGUIUtility.systemCopyBuffer, out Vector3 vector))
            {
                property.vector3Value = vector;
            }
        }
        
        private void ResetVector3(SerializedProperty property)
        {
            property.vector3Value = Vector3.zero;
        }  
    }
}
