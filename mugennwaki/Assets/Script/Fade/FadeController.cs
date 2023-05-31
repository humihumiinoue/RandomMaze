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
            if(MasterFade == null)
            {
                MasterFade = this.GetComponent<BaseFade>();
            }
            else
            {
                Destroy(this);
            }

            FadePanel = GetComponentInChildren<Image>();
            FadeScene = new FadeScene();
            FadeTimer = new valueObject.FadeTimer(BaseFade.MasterFade.DataFade.WaitFadeTimer);

            

            DontDestroyOnLoad(MasterFade);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

