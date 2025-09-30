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
            if (GUILayout.Button("C"))
            {
                CopyVector3(property); 
            }
            
            if (GUILayout.Button("P"))
            {
                PasteVector3(property);
            }
            
            if (GUILayout.Button("R"))
            {
                ResetVector3(property);
            }
            EditorGUILayout.EndHorizontal();
            
            property.vector3Value = EditorGUILayout.Vector3Field("", new Vector3(property.vector3Value.x,property.vector3Value.y, property.vector3Value.z));
            
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
