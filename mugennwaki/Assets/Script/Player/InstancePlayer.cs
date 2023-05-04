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
            BaseScript.MasterPlayer.PlayerDefaultPos
            = new Vector3(BaseScript.MasterStage.DigStartPosW.DigStartPosWidth
                        , 1
                        , BaseScript.MasterStage.DigStartPosH.DigStartPosHeight);

            // 生成する
            BaseScript.MasterPlayer.PlayerObj = MonoBehaviour.Instantiate(BaseScript.MasterPlayer.DataPlayer.PlayerPrefab
            , BaseScript.MasterPlayer.PlayerDefaultPos 
            , Quaternion.identity
            , BaseScript.MasterPlayer.ParentPlayer.transform);
        }
    }
}