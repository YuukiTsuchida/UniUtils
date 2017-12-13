using UnityEngine;
using UnityEditor;

namespace UniUtil
{
    namespace Scope
    {
        public class ContentsScope : GUI.Scope
        {
            public ContentsScope()
            {
                EditorGUILayout.BeginHorizontal("AS TextArea", GUILayout.MinHeight(10f));
                EditorGUILayout.BeginVertical();
            }

            protected override void CloseScope()
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
        }
    }
}
