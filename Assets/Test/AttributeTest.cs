using System;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTest : MonoBehaviour
{
    [Serializable]
    public struct SubSubNode
    {
        [UniUtil.Attribute.FindObjects("node")]
        public int num;
    }

    [Serializable]
    public struct SubNode
    {
        [UniUtil.Attribute.FindObjects("node")]
        public int[] num;

        public SubSubNode subNode;
    }

    [SerializeField, UniUtil.Attribute.FindObjects("GameObject")]
    private GameObject[] aaaa;


    [SerializeField, UniUtil.Attribute.FindObjects("GameObject ({0})")]
    private List<GameObject> bbb;

    [SerializeField]
    public SubNode node;
}
