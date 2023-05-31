using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using item;

namespace Count
{
    public class IncremantTime
    {
        public void ExpandTimer()
        {
            if(BaseItem.MasterItem.ItemObject)
            {
                BaseCount.MasterCount.NowTime = new valueObject.NowTime(BaseCount.MasterCount.NowTime.Number + 5);
            }
        }
    }
}
