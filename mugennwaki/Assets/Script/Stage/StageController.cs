using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using goal;
using fade;

namespace stage
{
    public class StageController : BaseStage
    {
        void Awake()
        {

            MasterStage = this.GetComponent<BaseStage>();

            Goal = new Goal();
            MakeStage = new MakeStage();
            StartWaitCount = new valueObject.StartWaitCount(MasterStage.DataStageScript.WaitStartCount);
            MazeSizeX = new valueObject.MazeSizeX(MasterStage.DataStageScript.MazeWidth);
            MazeSizeY = new valueObject.MazeSizeY(MasterStage.DataStageScript.MazeHeight);
            StageChalengeCount = new valueObject.StageChalengeCount(0);

            MasterStage.MakeStage.initializeMaze();
        }

        void Update()
        {
            MasterStage.Goal.GoalUpdate();
        }
    }
}
