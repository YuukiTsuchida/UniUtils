using UnityEngine;
using UnityEditor;

namespace UniUtil
{
    namespace UnityDefine
    {
        public class SceneDefineCreator
        {
            private static readonly string OutputPath = System.IO.Path.Combine(Application.dataPath, "Scripts/UnityDefine/Scene.cs");
                 // 宣言のテンプレート
            private const string ClassTemplate = @"
    namespace UnityDefine
    {{
        public static class Scene 
        {{
        {0}
        }}
    }}
             ";


             // defefineテンプレート
             private const string DefineTemplate = "public const string {0} = \"{1}\"; // {2} \n";

             [MenuItem("DefineCreate/Scene")]
             public static void Create()
            {
                var buildScenes = EditorBuildSettings.scenes;
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

                for( int i = 0; i < buildScenes.Length; ++i )
                {
                    var buildScene = buildScenes[i];
                    string sceneName = Utility.RemoveInvalidChars(System.IO.Path.GetFileNameWithoutExtension(buildScene.path));
                    string define = sceneName.ToUpper();
                    stringBuilder.Append(string.Format(DefineTemplate, define, sceneName, buildScene.path));
                }

                string outputStr = string.Format(ClassTemplate, stringBuilder.ToString());
                IO.Writer.Create(OutputPath, outputStr);
                AssetDatabase.Refresh();

            }
           
        }
    }
}
