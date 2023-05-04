using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace fade
{
    public class FadeScene
    {
        public void FadeOutStage()
        {
            BaseScript.MasterFade.FadePanel.DOFade(255, BaseScript.MasterFade.DataFade.WaitFadeTimer);
        }

        public void FadeInStage()
        {
            BaseScript.MasterFade.FadePanel.DOFade(0, BaseScript.MasterFade.DataFade.WaitFadeTimer);
        }
    }
}
