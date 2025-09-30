using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    public abstract class VectorPropertyDrawerBase : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(label);
            
            DrawVectorField(property);
            
            if (GUILayout.Button("C", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                CopyVector(property); 
            }
            
            if (GUILayout.Button("P", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                PasteVector(property);
            }
            
            if (GUILayout.Button("R", GUILayout.MinWidth(20), GUILayout.MaxWidth(30)))
            {
                ResetVector(property);
            }
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space(5);
        }

        protected abstract void DrawVectorField(SerializedProperty property);

        protected abstract void CopyVector(SerializedProperty property);

        protected abstract void PasteVector(SerializedProperty property);

        protected abstract void ResetVector(SerializedProperty property);
    }
}