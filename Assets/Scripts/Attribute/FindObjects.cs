using UnityEngine;

namespace UniUtil
{
    namespace Attribute
    {
        /**
         * シーンから特定のオブジェクトを検索する
         * 完全一致で動作する
         *
         * ※*特殊パターン*
         *      配列の場合 string.Format形式で記載することで各要素で検索するオブジェクトを変更することが可能
         *      "name{0}" と記載することでindex番号と合わせてオブジェクト名を検索する
         *      この場合 name0, name1, name2という具合になる
         **/
        public class FindObjects : PropertyAttribute
        {
            public string objectName;

            public FindObjects(string name)
            {
                objectName = name;
            }
        }
    }
}
