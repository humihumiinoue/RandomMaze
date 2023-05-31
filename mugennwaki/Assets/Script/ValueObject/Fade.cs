using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
namespace valueObject
{
    public class Fade
    {

    }

    /// <summary>
    /// ゴールした時に暗転するときの待ち時間
    /// </summary>
    public class FadeTimer
    {
        public float StageClearFadeTimer{get; private set;}

        // コンストラクタ
        public FadeTimer(float tmpTimer)
        {
            StageClearFadeTimer = tmpTimer;
        }
    }
}
