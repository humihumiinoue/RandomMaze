using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class BaseCamera : MonoBehaviour
    {        
        protected MoveCamera moveCameraScript = new MoveCamera();

        protected CameraRotate cameraRotateScript = new CameraRotate();

    }
}