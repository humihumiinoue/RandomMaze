using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class MoveCamera
    {
        public void MoveCameraUpdate()
        {
            setCamera();
        }

        // カメラの位置をプレイヤーと同期させる
        private void setCamera()
        {
            BaseScript.MasterCamera.MainCamera.transform.position = 
            BaseScript.MasterPlayer.PlayerObj.transform.position;
        }
    }
}