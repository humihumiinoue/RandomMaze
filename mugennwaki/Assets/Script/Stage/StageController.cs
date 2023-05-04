using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using goal;

namespace stage
{
    public class StageController : BaseStage
    {
        void Awake()
        {
            Goal = new Goal();
            MakeStage = new MakeStage();
            FadeTimer = new valueObject.FadeTimer();
            StartWaitCount = new valueObject.StartWaitCount(BaseScript.MasterStage.DataStageScript.WaitStartCount);
            MazeSizeX = new valueObject.MazeSizeX(BaseScript.MasterStage.DataStageScript.MazeWidth);
            MazeSizeY = new valueObject.MazeSizeY(BaseScript.MasterStage.DataStageScript.MazeHeight);

            BaseScript.MasterStage.MakeStage.initializeMaze();
        }

        void Update()
        {
            BaseScript.MasterStage.Goal.GoalUpdate();
        }
    }
}
