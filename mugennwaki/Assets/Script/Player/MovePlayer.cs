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
            // プレイヤーの前進
            playerMove();

            // プレイヤーの移動量を計測
            getPlayerMoveSpeed();

            if(!BaseScript.MasterStage.StageClearFlag)
            {
                // 移動可能かどうか
                moveFlagCheck();
            }
            
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
        public void moveFlagCheck()
        {
            // 移動終了後に移動可能にする
            if(BaseScript.MasterPlayer.PlayerRunSpeed_Z.playerRunSpeedAmount == 0)
            {
                BaseScript.MasterPlayer.PlayerMarchFlag = true;
            }
        }

        
        // プレイヤーを移動させる
        private void playerMove()
        {
            BaseScript.MasterPlayer.BeforeMovePlayerPos = BaseScript.MasterPlayer.PlayerObj.transform.localPosition;

            // 特定のボタンを押したかどうか
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {                
                // 前回の移動が終了したかどうか　接地しているかどうか
                if(BaseScript.MasterPlayer.PlayerMarchFlag
                && BaseScript.MasterPlayer.PlayerColWallFlag)
                {
                    // 1マスずつ前進する
                    BaseScript.MasterPlayer.PlayerObj.transform.DOMove(
                        BaseScript.MasterPlayer.PlayerObj.transform.forward,
                        BaseScript.MasterPlayer.DataPlayer.MarchSpeed,
                        false)
                    // 現在位置からの座標を参照
                    .SetRelative(true)
                    .OnStart(() =>
                    {
                        // 連打防止用
                        BaseScript.MasterPlayer.PlayerMarchFlag = false;
                    })
                    .OnComplete(() =>
                    {
                        // 位置を矯正
                        RoundToInt();

                        // 移動フラグをオン
                        BaseScript.MasterPlayer.PlayerMarchFlag = true;
                    })
                    .SetAutoKill(false);
                }
            }
        }

        // 壁に向かって歩く
        public void HitWall()
        {
            BaseScript.MasterPlayer.BeforeMovePlayerPos = BaseScript.MasterPlayer.PlayerObj.transform.localPosition;

            // 壁に進む
            BaseScript.MasterPlayer.PlayerObj.transform.DOMove(
                BaseScript.MasterPlayer.PlayerObj.transform.forward 
                / BaseScript.MasterPlayer.DataPlayer.MoveDirection
                , BaseScript.MasterPlayer.DataPlayer.MarchSpeed
                , false
            )
            // 現在位置から移動
            .SetRelative(true)
            // 終わった後破棄しない
            .SetAutoKill(false)
            .OnStart(() => 
            {
                // 壁に当たって跳ね返るアニメーションのフラグをオフ
                BaseScript.MasterPlayer.PlayerColWallFlag = false;
            })
            .OnComplete(() =>
            {
                // 後ろに跳ね返される
                BackJump();
            });
        }

        // 壁にぶつかって後ろにはじかれる
        private void BackJump()
        {

            // 壁にぶつかって後ろにはじかれる
            BaseScript.MasterPlayer.PlayerObj.transform.DOJump(
                -BaseScript.MasterPlayer.PlayerObj.transform.forward /
                BaseScript.MasterPlayer.DataPlayer.MoveDirection,
                BaseScript.MasterPlayer.DataPlayer.HitWallJumpPower,
                1,
                BaseScript.MasterPlayer.DataPlayer.MarchSpeed,
                false
            )
            .SetRelative(true)
            .SetAutoKill(false)
            .OnComplete(() =>
            {
                // 位置を補正
                RoundToInt();

                // 壁に当たって跳ね返るアニメーションのフラグをオン
                BaseScript.MasterPlayer.PlayerColWallFlag = true;
            });
        }

        // 位置を補正する
        private void RoundToInt()
        {
            Vector3 tmpPos;

            // 位置を矯正
            tmpPos = BaseScript.MasterPlayer.PlayerObj.transform.localPosition;
            tmpPos.x = Mathf.RoundToInt(BaseScript.MasterPlayer.BeforeMovePlayerPos.x);
            tmpPos.y = Mathf.RoundToInt(BaseScript.MasterPlayer.BeforeMovePlayerPos.y);
            tmpPos.z = Mathf.RoundToInt(BaseScript.MasterPlayer.BeforeMovePlayerPos.z);
            BaseScript.MasterPlayer.PlayerObj.transform.localPosition = tmpPos;
        }
    }
}

