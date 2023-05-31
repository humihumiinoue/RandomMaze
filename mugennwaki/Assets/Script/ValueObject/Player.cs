using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace valueObject
{
    public class Player
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

    // プレイヤーがゴールした時に移動する距離のクラス
    public sealed class PlayerGoToNextStage
    {
        public float GoToNextStageDirection{get; private set;}

        // コンストラクタ
        public PlayerGoToNextStage(float tmpDirection)
        {
            GoToNextStageDirection = tmpDirection;
        }
    }

    public sealed class PlayerGetItem
    {
        public int Count{get; private set;}

        public PlayerGetItem(int tmpCount)
        {
            Count = tmpCount;
        }
    }
}

