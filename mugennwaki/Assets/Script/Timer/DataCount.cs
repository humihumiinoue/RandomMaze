using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "DataCount", menuName = "SriptableObjects/CountAsset")]
    public class DataCount : ScriptableObject
    {
        [SerializeField, Header("制限時間")]
        private float limitTime;
        public float LimitTime{get{return limitTime;}}
        
    }
}
