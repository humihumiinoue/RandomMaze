using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public class PlayerRotate
    {
        // プレイヤー回転関数まとめ
        public void PlayerRotateUpdate()
        {
            lookSidePlayer();
        }

        // 振り向き関数
        private void lookSidePlayer()
        {
            // 向いている方向
            Vector3 playerDefaultRotate = BaseScript.MasterPlayer.PlayerObj.transform.eulerAngles;

            // 回転方向と大きさ　四方向なので90
            Vector3 playerLeftRotateValue = new Vector3(0, Mathf.RoundToInt(playerDefaultRotate.y - 90), 0);
            Vector3 playerRightRotateValue = new Vector3(0, Mathf.RoundToInt(playerDefaultRotate.y + 90), 0);
            // 後ろを向くため180
            Vector3 playerBackRotateValue = new Vector3(0, Mathf.RoundToInt(playerDefaultRotate.y + 180), 0);

            // 停止しているなら
            if(Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // 回転させる
                rotatePlayer(playerLeftRotateValue);
                            return;
            }

            if(Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // 回転させる
                rotatePlayer(playerRightRotateValue);
                            return;
            }

            if(Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // 回転させる
                rotatePlayer(playerBackRotateValue);
                            return;
            }
        }

        /// <summary>
        /// 回転詳細
        /// </summary>
        /// <param name="rotateValue">回転量はどれくらいか</param>
        private void rotatePlayer(Vector3 rotateValue)
        {
            if(BaseScript.MasterPlayer.PlayerRotateFlag)
            {
                // 回転する
                BaseScript.MasterPlayer.PlayerObj.transform.DORotate(
                      rotateValue
                    , BaseScript.MasterPlayer.DataPlayer.RotateSpeed
                    , RotateMode.Fast
                )
                .OnStart(() =>
                {
                    // 連打防止・回転中の回転禁止
                    BaseScript.MasterPlayer.PlayerRotateFlag = false;
                    // 移動できなくする
                    BaseScript.MasterPlayer.PlayerMarchFlag = false;
                })
                .OnComplete(() =>
                {
                    // 回転可能にする
                    BaseScript.MasterPlayer.PlayerRotateFlag = true;
                    // 移動可能にする
                    BaseScript.MasterPlayer.PlayerMarchFlag = true;
                });
            }
        }
    }
}

