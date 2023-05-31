using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace valueObject
{
    public class Item
    {
        
    }

    // アイテム上限クラス
    public class ItemOverFlow
    {
        public int Number{get; private set;}

        public ItemOverFlow(int tmpNum)
        {
            Number = tmpNum;
        }
    }

    // 現在のアイテム数
    public class ItemPop
    {
        public int Count{get; private set;}

        public ItemPop(int tmpCount)
        {
            Count = tmpCount;
        }
    }
}

