using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class CameraRotate
    {
        public void RotateCameraUpdate()
        {
            rotateCamera();
        }

        // カメラの向きをプレイヤーと同期させる
        private void rotateCamera()
        {
            BaseScript.MasterCamera.MainCamera.transform.eulerAngles =
            BaseScript.MasterPlayer.PlayerObj.transform.eulerAngles;
        }
    }
}
