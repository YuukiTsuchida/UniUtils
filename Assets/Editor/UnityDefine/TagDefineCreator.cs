using UnityEditor;
using UnityEngine;


namespace UniUtil
{
    namespace UnityDefine
    {
        public class TagDefineCreator
        {
            private static readonly string OutputPath = System.IO.Path.Combine( Application.dataPath, "Scripts/UnityDefine/Tag.cs" );

            // 宣言のテンプレート
            private const string ClassTemplate = @"
    namespace UnityDefine
    {{
        public static class Tag
        {{
        {0}
        }}
    }}
             ";


             // enumのdefefineテンプレート
             private const string DefineTemplate = "public const string {0} = \"{1}\"; \n";


            /// <summary>
            /// タグから定数宣言のソースを出力する.
            /// </summary>
            [MenuItem("DefineCreate/Tag")]
            public static void Create()
            {
                string[] tags = UnityEditorInternal.InternalEditorUtility.tags;

                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

                foreach( string tag in tags )
                {
                    string define = Utility.RemoveInvalidChars(tag).ToUpper();
                    stringBuilder.Append(string.Format(DefineTemplate, define, tag));
                }

                string outputStr = string.Format(ClassTemplate, stringBuilder.ToString());

                IO.Writer.Create(OutputPath, outputStr);

                AssetDatabase.Refresh();
            }
        }

    }
}
