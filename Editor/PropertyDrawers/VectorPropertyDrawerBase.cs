#if ODIN_INSPECTOR
using Sirenix.OdinInspector.Editor;
#endif
using UnityEditor;
using UnityEngine;

namespace HaiitoCorp.LittleInspector.Editor.PropertyDrawers
{
    #if ODIN_INSPECTOR

    public abstract class VectorOdinValueDrawerBase<T> : OdinValueDrawer<T> where T : struct
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            T value = this.ValueEntry.SmartValue;

            if (label == null) label = CreateLabel();
            
            GUILayout.BeginHorizontal();
            value = DrawVectorField(label, value);

            GUILayoutOption[] btnLayoutOptions =
                { GUILayout.MinWidth(20), GUILayout.MaxWidth(20), GUILayout.MinHeight(20), GUILayout.MaxHeight(20) };
            
            if (GUILayout.Button("C", btnLayoutOptions))
            {
                CopyVector(value); 
            }
            
            if (GUILayout.Button("P", btnLayoutOptions))
            {
                value = PasteVector(value);
            }
            
            if (GUILayout.Button("R", btnLayoutOptions))
            {
                value = ResetVector();
            }
            GUILayout.EndHorizontal();
            
            GUILayout.Space(5);
            
            this.ValueEntry.SmartValue = value;
        }

        protected abstract GUIContent CreateLabel();
        
        protected abstract T DrawVectorField(GUIContent label, T value);

        protected abstract void CopyVector(T value);

        protected abstract T PasteVector(T currentValue);

        protected abstract T ResetVector();
    }
    #else
    public abstract class VectorPropertyDrawerBase : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(label);
            
            DrawVectorField(property);
            
            GUILayoutOption[] btnLayoutOptions =
                { GUILayout.MinWidth(20), GUILayout.MaxWidth(20), GUILayout.MinHeight(20), GUILayout.MaxHeight(20) };

            if (GUILayout.Button("C", btnLayoutOptions))
            {
                CopyVector(property); 
            }
            
            if (GUILayout.Button("P", btnLayoutOptions))
            {
                PasteVector(property);
            }
            
            if (GUILayout.Button("R", btnLayoutOptions))
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
#endif
}