using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using fade;

namespace fade
{
    public class FadeScene
    {
        public void FadeOutStage()
        {
            BaseFade.MasterFade.FadePanel.DOFade(255, BaseFade.MasterFade.DataFade.WaitFadeTimer);
        }

        public void FadeInStage()
        {
            BaseFade.MasterFade.FadePanel.DOFade(0, BaseFade.MasterFade.DataFade.WaitFadeTimer);
        }
    }
}
