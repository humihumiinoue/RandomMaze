using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Count
{
    public class CountDown
    {
        public void CountDownUpdate()
        {
            countDownTimer();
        }

        private void countDownTimer()
        {
            
            // 文字に起こす
            BaseCount.MasterCount.DispTime = new valueObject.DispTime(BaseCount.MasterCount.NowTime.Number);

            // テキストに適応
            BaseCount.MasterCount.TimeCountText.text = string.Format("{0:00.0}", BaseCount.MasterCount.DispTime.Count);

            // 時間減少
            BaseCount.MasterCount.NowTime = new valueObject.NowTime(BaseCount.MasterCount.NowTime.Number - (Time.deltaTime));

            // マイナスにしない
            if(BaseCount.MasterCount.NowTime.Number <= 0)
            {
                BaseCount.MasterCount.NowTime = new valueObject.NowTime(0);
            }
        }
    }
}

