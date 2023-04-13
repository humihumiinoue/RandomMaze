using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public class MovePlayer
    {
        /// <summary>
        /// 移動系関数まとめ
        /// </summary>
        public void MovePlayerUpdate()
        {
            playerMove();

            getPlayerMoveSpeed();

            moveFlagCheck();
        }

        /// <summary>
        /// 移動量を計測
        /// </summary>
        private void getPlayerMoveSpeed()
        {
            BaseScript.MasterPlayer.PlayerRunSpeed_Z = new valueObject.PlayerRunSpeed(Input.GetAxis("Vertical"));

            // 後退禁止
            if(BaseScript.MasterPlayer.PlayerRunSpeed_Z.playerRunSpeedAmount < 0)
            {
                BaseScript.MasterPlayer.PlayerRunSpeed_Z = new valueObject.PlayerRunSpeed(0);
            }
        }

        /// <summary>
        /// 移動終了後に移動可能にする
        /// </summary>
        private void moveFlagCheck()
        {
            // 移動終了後に移動可能にする
            if(BaseScript.MasterPlayer.PlayerRunSpeed_Z == new valueObject.PlayerRunSpeed(0))
            {
                BaseScript.MasterPlayer.PlayerMarchFlag = true;
            }
        }

        
        // プレイヤーを移動させる
        private void playerMove()
        {
            // 特定のボタンを押したかどうか
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {                
                // 前回の移動が終了したかどうか　接地しているかどうか
                if(BaseScript.MasterPlayer.PlayerMarchFlag
                && BaseScript.MasterPlayer.PlayerColWallFlag)
                {
                    // 1マスずつ前進する
                    BaseScript.MasterPlayer.PlayerObj.transform.DOMove(new Vector3
                    ( Mathf.RoundToInt(BaseScript.MasterPlayer.PlayerObj.transform.forward.x)
                    , Mathf.RoundToInt(BaseScript.MasterPlayer.PlayerObj.transform.forward.y)
                    , Mathf.RoundToInt(BaseScript.MasterPlayer.PlayerObj.transform.forward.z))
                    , BaseScript.MasterPlayer.ScriptablePlayerScript.MarchSpeed
                    , false)
                    // 現在位置からの座標を参照
                    .SetRelative(true)
                    .OnStart(() =>
                    {
                        // 連打防止用
                        BaseScript.MasterPlayer.PlayerMarchFlag = false;
                    })
                    .OnComplete(() =>
                    {
                        // 移動フラグをオン
                        BaseScript.MasterPlayer.PlayerMarchFlag = true;
                    });
                }
            }
        }
    }
}

