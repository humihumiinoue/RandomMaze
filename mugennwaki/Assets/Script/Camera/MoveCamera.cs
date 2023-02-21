using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class MoveCamera
    {
        public void SetCamera()
        {
            // カメラの位置を設置・全体を見渡す
            BaseBase.TmpCamera.MainCamera.transform.position = BaseBase.TmpStage.Centered + Vector3.back 
                                                            * ((BaseBase.TmpStage.MazeWidth + BaseBase.TmpStage.MazeHeight) >> 1);
        }
    }
}