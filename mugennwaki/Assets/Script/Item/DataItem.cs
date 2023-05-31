using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace item
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "SriptableObjects/ItemAsset")]
    public class DataItem : ScriptableObject
    {
        [SerializeField, Header("アイテムオブジェクト")]
        private GameObject itemPrefab;
        public GameObject ItemPrefab{get{return itemPrefab;}}

        [SerializeField, Header("アイテムの上限")]
        private int overLimitItemNum;
        public int OverLimitItemNum{get{return overLimitItemNum;}}
    }
}
