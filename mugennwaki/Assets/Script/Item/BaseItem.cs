using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using valueObject;
using DG.Tweening;

namespace item
{
    public class BaseItem : MonoBehaviour
    {
        private GameObject itemObject;
        public GameObject ItemObject{get{return itemObject;} set{itemObject = value;}}

        [SerializeField, Header("アイテムまとめ親")]
        private GameObject itemManager;
        public GameObject ItemManager{get{return itemManager;} set{itemManager = value;}}

        public GameObject[] ItemArray{get; protected set;}

        public ItemOverFlow OverLImit{get; set;}

        public ItemPop ItemPop{get; set;}


        public Item Item{get; protected set;}

        [SerializeField]
        private DataItem dataItem;
        public DataItem DataItem{get{return dataItem;} protected set{dataItem = value;}}

        public Create Create{get; protected set;}

        public Delete Delete{get; protected set;}

        public Activation Activation{get; protected set;}

        public PlaceMent PlaceMent{get; protected set;}

        
        private static BaseItem masterItem;
        public static BaseItem MasterItem{get{return masterItem;} set{masterItem = value;}}
    }

}