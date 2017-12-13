using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace UniUtil
{
    namespace Attribute
    {
        [CustomPropertyDrawer(typeof(FindObjects))]
        public class FindObjectsDrawer : PropertyDrawer
        {
            private const float Width = 100.0f;

            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                return EditorGUIUtility.singleLineHeight;
            }

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                position.height = EditorGUIUtility.singleLineHeight;
                position.width -= Width;
                EditorGUI.PropertyField(position, property);

                position.x = position.width;
                position.width = Width;
                if(GUI.Button(position, "Search"))
                {
                    Search(property);
                }
            }

            private void Search(SerializedProperty property)
            {
                FindObjects instance = (FindObjects)attribute;
                var nestedProperty = property.propertyPath.Split('.');
                string findObjectName = instance.objectName;

                // ネストされたプロパティが3以上のときは
                // 配列の可能性があるので
                if(nestedProperty.Length >= 3)
                {
                    StringBuilder builder = new StringBuilder();
                    for(int i = 0; i < nestedProperty.Length - 2; ++i)
                    {
                        builder.Append(nestedProperty[i]);

                        if(i + 1 != nestedProperty.Length - 2)
                        {
                            builder.Append('.');
                        }
                    }

                    // ここでvectorだと配列と判定
                    if(property.serializedObject.FindProperty(builder.ToString()).type == "vector")
                    {
                        var contentMatchPattern = Regex.Match(nestedProperty[nestedProperty.Length - 1], "data\\[([0-9]+)\\]");
                        var currentIndex = contentMatchPattern.Groups[1]; 
                        if(contentMatchPattern.Success)
                        {
                            findObjectName = string.Format(findObjectName, currentIndex);
                        }
                    }
                }
    
                GameObject target = GameObject.Find(findObjectName);
                if(target != null)
                {
                    property.objectReferenceValue = target;
                }
                else
                {
                    UnityEngine.Debug.LogErrorFormat("not found object : {0}", findObjectName);
                }
            }
        }
    }
}
