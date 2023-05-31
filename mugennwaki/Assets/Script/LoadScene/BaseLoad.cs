using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace load
{
    public class BaseLoad : MonoBehaviour
    {
        public Move Move{get; set;}

        [SerializeField]
        private GameObject loadManager;
        public GameObject LoadManager{get{return loadManager;} set{loadManager = value;}}

        
        private static BaseLoad masterLoad;
        public static BaseLoad MasterLoad{get{return masterLoad;} set{masterLoad = value;}}
    }
}

