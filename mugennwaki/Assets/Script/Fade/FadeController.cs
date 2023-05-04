using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace fade
{
    public class FadeController : BaseFade
    {
        // Start is called before the first frame update
        void Start()
        {
            FadePanel = GetComponentInChildren<Image>();
            FadeScene = new FadeScene();
            FadeTimer = new valueObject.FadeTimer();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

