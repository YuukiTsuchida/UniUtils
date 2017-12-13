using UnityEditor;
using UnityEngine;

namespace UniUtil
{
    namespace UnityDefine
    {
        public class LayerDefineCreator
        {
            private static readonly string OutputPath = System.IO.Path.Combine( Application.dataPath, "Scripts/UnityDefine/Layer.cs" );

            // 宣言のテンプレート
            private const string ClassTemplate = @"
        namespace UnityDefine
        {{
            public static class Layer
            {{
            {0}
            }}
        }}
             ";


             // defefineテンプレート
             private const string DefineTemplate = "public const string {0} = \"{1}\"; \n";


            [MenuItem("DefineCreate/Layer")]
            public static void Create()
            {
            string[] layers = UnityEditorInternal.InternalEditorUtility.layers;

            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            foreach( string layer in layers )
            {
                string define = Utility.RemoveInvalidChars( layer ).ToUpper();
                stringBuilder.Append( string.Format( DefineTemplate, define, layer ) );
            }

            string outputStr = string.Format( ClassTemplate, stringBuilder.ToString() );

            IO.Writer.Create( OutputPath, outputStr );

            AssetDatabase.Refresh();
            }
        }
    }
}
