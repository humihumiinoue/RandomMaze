using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stage;

namespace president
{
    public class DispLayScore
    {
        public void DispLayFloor()
        {
            BaseStage.MasterStage.ScoreText.text = BaseStage.MasterStage.StageChalengeCount.StageCount.ToString() + " かい";
        }
    }
}

