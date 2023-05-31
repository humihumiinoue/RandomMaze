using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace item
{
    public class ItemController : BaseItem
    {
        // Start is called before the first frame update
        void Start()
        {
            MasterItem = this.GetComponent<BaseItem>();

            OverLImit = new valueObject.ItemOverFlow(DataItem.OverLimitItemNum);
            ItemPop = new valueObject.ItemPop(0);
            Create = new Create();
            Delete = new Delete();
            Activation = new Activation();
            PlaceMent = new PlaceMent();
            
            Create.InstanceUpdate();

            ItemArray = new GameObject[DataItem.OverLimitItemNum];

            for(int k = 0; k < OverLImit.Number; k++)
            {
                // 配列を書き換える
                ItemArray[k] = ItemManager.transform.GetChild(k).gameObject;
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

