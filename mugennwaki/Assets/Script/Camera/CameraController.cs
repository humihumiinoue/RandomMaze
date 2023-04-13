using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class CameraController : BaseCamera
    {
        private void Awake()
        {
            MainCamera = GetComponent<Camera>();
        }
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            moveCameraScript.MoveCameraUpdate();

            cameraRotateScript.RotateCameraUpdate();
        }
    }
}