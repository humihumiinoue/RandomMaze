using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class BaseCamera : MonoBehaviour
    {
        public Camera MainCamera{get; protected set;}
        
        protected MoveCamera moveCameraScript = new MoveCamera();

        protected CameraRotate cameraRotateScript = new CameraRotate();
    }
}