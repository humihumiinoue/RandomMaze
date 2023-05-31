using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using stage;

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

            if(!BaseStage.MasterStage.StageClearFlag)
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
            BasePlayer.MasterPlayer.PlayerRunSpeed_Z = new valueObject.PlayerRunSpeed(Input.GetAxis("Vertical"));

            // 後退禁止
            if(BasePlayer.MasterPlayer.PlayerRunSpeed_Z.playerRunSpeedAmount < 0)
            {
                BasePlayer.MasterPlayer.PlayerRunSpeed_Z = new valueObject.PlayerRunSpeed(0);
            }
        }

        /// <summary>
        /// 移動終了後に移動可能にする
        /// </summary>
        public void moveFlagCheck()
        {
            // 移動終了後に移動可能にする
            if(BasePlayer.MasterPlayer.PlayerRunSpeed_Z.playerRunSpeedAmount == 0)
            {
                BasePlayer.MasterPlayer.PlayerMarchFlag = true;
            }
        }

        
        // プレイヤーを移動させる
        private void playerMove()
        {
            BasePlayer.MasterPlayer.BeforeMovePlayerPos = BasePlayer.MasterPlayer.PlayerObj.transform.localPosition;

            // 特定のボタンを押したかどうか
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {                
                // 前回の移動が終了したかどうか　接地しているかどうか
                if(BasePlayer.MasterPlayer.PlayerMarchFlag
                && BasePlayer.MasterPlayer.PlayerColWallFlag)
                {
                    // 1マスずつ前進する
                    BasePlayer.MasterPlayer.PlayerObj.transform.DOMove(
                        BasePlayer.MasterPlayer.PlayerObj.transform.forward,
                        BasePlayer.MasterPlayer.DataPlayer.MarchSpeed,
                        false)
                    // 現在位置からの座標を参照
                    .SetRelative(true)
                    .OnStart(() =>
                    {
                        // 連打防止用
                        BasePlayer.MasterPlayer.PlayerMarchFlag = false;
                        // 移動中の回転を禁止
                        BasePlayer.MasterPlayer.PlayerRotateFlag = false;
                    })
                    .OnComplete(() =>
                    {
                        // 位置を矯正
                        RoundToInt();

                        // 移動フラグをオン
                        BasePlayer.MasterPlayer.PlayerMarchFlag = true;
                        BasePlayer.MasterPlayer.PlayerRotateFlag = true;
                    })
                    .SetAutoKill(false);
                }
            }
        }

        // 壁に向かって歩く
        public void HitWall()
        {
            BasePlayer.MasterPlayer.BeforeMovePlayerPos = BasePlayer.MasterPlayer.PlayerObj.transform.localPosition;

            // 壁に進む
            BasePlayer.MasterPlayer.PlayerObj.transform.DOMove(
                BasePlayer.MasterPlayer.PlayerObj.transform.forward 
                / BasePlayer.MasterPlayer.DataPlayer.MoveDirection
                , BasePlayer.MasterPlayer.DataPlayer.MarchSpeed
                , false
            )
            // 現在位置から移動
            .SetRelative(true)
            // 終わった後破棄しない
            .SetAutoKill(false)
            .OnStart(() => 
            {
                // 壁に当たって跳ね返るアニメーションのフラグをオフ
                BasePlayer.MasterPlayer.PlayerColWallFlag = false;
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
            BasePlayer.MasterPlayer.PlayerObj.transform.DOJump(
                -BasePlayer.MasterPlayer.PlayerObj.transform.forward /
                BasePlayer.MasterPlayer.DataPlayer.MoveDirection,
                BasePlayer.MasterPlayer.DataPlayer.HitWallJumpPower,
                1,
                BasePlayer.MasterPlayer.DataPlayer.MarchSpeed,
                false
            )
            .SetRelative(true)
            .SetAutoKill(false)
            .OnComplete(() =>
            {
                // 位置を補正
                RoundToInt();

                // 壁に当たって跳ね返るアニメーションのフラグをオン
                BasePlayer.MasterPlayer.PlayerColWallFlag = true;
            });
        }

        // 位置を補正する
        private void RoundToInt()
        {
            Vector3 tmpPos;

            // 位置を矯正
            tmpPos = BasePlayer.MasterPlayer.PlayerObj.transform.localPosition;
            tmpPos.x = Mathf.RoundToInt(BasePlayer.MasterPlayer.BeforeMovePlayerPos.x);
            tmpPos.y = Mathf.RoundToInt(BasePlayer.MasterPlayer.BeforeMovePlayerPos.y);
            tmpPos.z = Mathf.RoundToInt(BasePlayer.MasterPlayer.BeforeMovePlayerPos.z);
            BasePlayer.MasterPlayer.PlayerObj.transform.localPosition = tmpPos;
        }
    }
}

