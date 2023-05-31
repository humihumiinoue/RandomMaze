using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Count
{
    public class TimeCountController : BaseCount
    {
        void Start()
        {
            TimeCount = new valueObject.TimeCount(DataCount.LimitTime);
            NowTime = new valueObject.NowTime(DataCount.LimitTime);
            CountDown = new CountDown();
            TimeUp = new TimeUp();
            IncremantTime = new IncremantTime();
            MasterCount = this.GetComponent<BaseCount>();
        }

        void Update()
        {
            CountDown.CountDownUpdate();

            TimeUp.FinishGame();

            
        }
    }
}
