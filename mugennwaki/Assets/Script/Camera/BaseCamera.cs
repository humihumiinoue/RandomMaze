using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace camera
{
    public class BaseCamera : MonoBehaviour
    {
        [SerializeField, Header("メインカメラ")]
        protected Camera mainCamera;
        public Camera MainCamera{get{return mainCamera;}protected set{mainCamera = value;}}
        protected MoveCamera moveCamera = new MoveCamera();
    }
}