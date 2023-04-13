using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace valueObject
{
    public class ValueObject
    {
        
    }

    // プレイヤー移動速度クラス
    public sealed class PlayerRunSpeed
    {
        public float playerRunSpeedAmount{get; private set;}

        // コンストラクタ
        public PlayerRunSpeed(float amount)
        {
            // 値の初期化
            playerRunSpeedAmount = amount;
        }
    }
}

