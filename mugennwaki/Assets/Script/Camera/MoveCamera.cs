using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

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
            Camera.main.transform.position = 
                BasePlayer.MasterPlayer.PlayerObj.transform.localPosition;
        }
    }
}