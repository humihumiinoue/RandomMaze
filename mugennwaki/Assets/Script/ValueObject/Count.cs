using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace valueObject
{
    public class Count
    {
        
    }

    /// <summary>
    /// 制限時間
    /// </summary>
    public sealed class TimeCount
    {
        public float Limit{get; private set;}

        public TimeCount(float tmpLimit)
        {
            Limit = tmpLimit;
        }
    }

    /// <summary>
    /// 内部的残り時間
    /// </summary>
    public sealed class NowTime
    {
        public float Number{get; private set;}

        public NowTime(float tmpNumber)
        {
            Number = tmpNumber;
        }
    }

    /// <summary>
    /// 画面に表示する残り時間
    /// </summary>
    public sealed class DispTime
    {
        public float Count{get; private set;}

        public DispTime(float tmpCount)
        {
            Count = tmpCount;
        }
    }
}
