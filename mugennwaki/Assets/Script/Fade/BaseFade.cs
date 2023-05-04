using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using data;
using valueObject;

namespace fade
{
    public class BaseFade : MonoBehaviour
    {
        private Image fadePanel;
        public Image FadePanel{get{return fadePanel;} set{fadePanel = value;}}

        [SerializeField]
        private DataFade dataFade;
        public DataFade DataFade{get{return dataFade;}}

        public FadeScene FadeScene{get; protected set;}

        public FadeTimer FadeTimer{get; protected set;}
    }
}
