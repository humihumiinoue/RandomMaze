using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

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
            Camera.main.transform.eulerAngles =
            BasePlayer.MasterPlayer.PlayerObj.transform.eulerAngles;
        }
    }
}
