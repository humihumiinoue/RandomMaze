using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stage;

namespace Player
{
    public class InstancePlayer
    {
        // プレイヤーを生成
        public void instancePlayer()
        {
            // プレイヤーの初期位置を設定
            BasePlayer.MasterPlayer.PlayerDefaultPos
            = new Vector3(BaseStage.MasterStage.DigStartPosW.DigStartPosWidth
                        , 1
                        , BaseStage.MasterStage.DigStartPosH.DigStartPosHeight);

            // 生成する
            BasePlayer.MasterPlayer.PlayerObj = MonoBehaviour.Instantiate(BasePlayer.MasterPlayer.DataPlayer.PlayerPrefab
            , BasePlayer.MasterPlayer.PlayerDefaultPos 
            , Quaternion.identity
            , BasePlayer.MasterPlayer.ParentPlayer.transform);
        }
    }
}