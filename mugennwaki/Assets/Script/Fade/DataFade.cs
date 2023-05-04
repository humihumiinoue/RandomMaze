using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "FadeData", menuName = "SriptableObjects/FadeParamAsset")]
    public class DataFade : ScriptableObject
    {
        [SerializeField, Header("ゴールした時に暗転するときの待ち時間")]
        private float waitFadeTimer;
        public float WaitFadeTimer{get{return waitFadeTimer;}}
    }
}
