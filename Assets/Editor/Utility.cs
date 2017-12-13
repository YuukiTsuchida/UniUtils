using System;
using UnityEditor;
using UnityEngine;


namespace UniUtil
{

    public static class Utility
    {
        // 無効な文字を管理する配列
        private static readonly string[] InvalidChars = {
            " ", "!", "\"", "#", "$",
            "%", "&", "\'", "(", ")",
            "-", "=", "^",  "~", "\\",
            "|", "[", "{",  "@", "`",
            "]", "}", ":",  "*", ";",
            "+", "/", "?",  ".", ">",
            ",", "<"
        };

        public static string RemoveInvalidChars(string str)
        {
            Array.ForEach(InvalidChars, c => str = str.Replace(c, string.Empty));
            return str;
        }

        public static void Indent( System.Action task )
        {
            EditorGUI.indentLevel++;

            task();

            EditorGUI.indentLevel--;
        }

        public static void BeginProperty( Rect position, GUIContent content, SerializedProperty property, System.Action task )
        {
            EditorGUI.BeginProperty( position, content, property );

            task();

            EditorGUI.EndProperty();
        }
    }
}
