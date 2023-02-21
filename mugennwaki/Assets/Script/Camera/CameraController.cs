using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class CameraController : BaseCamera
    {
        // Start is called before the first frame update
        void Start()
        {
            MainCamera = GetComponent<Camera>();
            moveCamera.SetCamera();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}