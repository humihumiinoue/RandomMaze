using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Count;


namespace president
{
    public class GameEnd
    {
        public void Finish()
        {
            if(BaseCount.MasterCount.NowTime.Number <= 0)
            {
                BaseGame.MasterGame.Phase = BaseGame.GameState.End;
            }
        }
    }
}

