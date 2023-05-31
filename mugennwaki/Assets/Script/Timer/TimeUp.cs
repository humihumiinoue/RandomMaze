using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using load;

namespace Count
{
    public class TimeUp
    {
        public void FinishGame()
        {
            if(BaseCount.MasterCount.NowTime.Number <= 0)
            {
                BaseLoad.MasterLoad.Move.LoadScene(2);
            }
                
        }
    }
}

