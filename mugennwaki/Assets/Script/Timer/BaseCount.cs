using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using data;
using UnityEngine.UI;
using valueObject;

namespace Count
{
    public class BaseCount : MonoBehaviour
    {
        
        public DataCount DataCount{get{return dataCount;} set{dataCount = value;}}
        [SerializeField]
        private DataCount dataCount;


        public Text TimeCountText{get{return timeCountText;} set{timeCountText = value;}}
        [SerializeField, Header("残り時間表示テキスト")]
        private Text timeCountText;

        public CountDown CountDown{get; set;}
        
        public TimeCount TimeCount{get; set;}

        public NowTime NowTime{get; set;}

        public DispTime DispTime{get; set;}

        public FadeTimer FadeTimer{get; set;}

        public TimeUp TimeUp{get; set;}

        public IncremantTime IncremantTime{get; set;}


        private static BaseCount masterCount;
        public static BaseCount MasterCount{get{return masterCount;} set{masterCount = value;}}
    }
}

