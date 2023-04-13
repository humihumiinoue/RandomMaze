using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using valueObject;

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
            Vector3 playerLeftRotateValue = new Vector3(0, (playerDefaultRotate.y - 90), 0);
            Vector3 playerRightRotateValue = new Vector3(0, (playerDefaultRotate.y + 90), 0);
            // 後ろを向くため180
            Vector3 playerBackRotateValue = new Vector3(0, Mathf.RoundToInt(playerDefaultRotate.y + 180), 0);

            // 移動可能かどうか
            if(BaseScript.MasterPlayer.PlayerMarchFlag)
            {
                // 回転させる
                rotatePlayer(Input.GetKeyDown(KeyCode.A)
                , Input.GetKeyDown(KeyCode.LeftArrow)
                , BaseScript.MasterPlayer.PlayerRotateFlag
                , playerLeftRotateValue);
            }

            if(BaseScript.MasterPlayer.PlayerMarchFlag)
            {
                // 回転させる
                rotatePlayer(Input.GetKeyDown(KeyCode.D)
                , Input.GetKeyDown(KeyCode.RightArrow)
                , BaseScript.MasterPlayer.PlayerRotateFlag
                , playerRightRotateValue);
            }

            if(BaseScript.MasterPlayer.PlayerMarchFlag)
            {
                // 回転させる
                rotatePlayer(Input.GetKeyDown(KeyCode.S)
                , Input.GetKeyDown(KeyCode.DownArrow)
                , BaseScript.MasterPlayer.PlayerRotateFlag
                , playerBackRotateValue);
            }
        }

        /// <summary>
        /// 回転詳細
        /// </summary>
        /// <param name="WASD">WASDのどれを押したか</param>
        /// <param name="arrow">矢印キーのどれを押したか</param>
        /// <param name="rotateFlag">回転フラグはどうなっているか</param>
        /// <param name="rotateValue">回転量はどれくらいか</param>
        private void rotatePlayer(bool WASD, bool arrow, bool rotateFlag, Vector3 rotateValue)
        {
            if(WASD || arrow && rotateFlag)
            {
                // 連打防止・回転中の回転禁止
                rotateFlag = false;

                // 後ろ向く
                BaseScript.MasterPlayer.PlayerObj.transform.DORotate(
                    rotateValue
                    , BaseScript.MasterPlayer.ScriptablePlayerScript.RotateSpeed
                    , RotateMode.Fast
                )
                .OnStart(() =>
                {
                    // 移動できなくする
                    BaseScript.MasterPlayer.PlayerMarchFlag = false;
                })
                .OnUpdate(() =>
                {
                    // 回転中の移動禁止
                    BaseScript.MasterPlayer.PlayerRunSpeed_Z = new valueObject.PlayerRunSpeed(0);
                }
                )
                .OnComplete(() =>
                {
                    // 回転可能にする
                    rotateFlag = true;
                    // 移動可能にする
                    BaseScript.MasterPlayer.PlayerMarchFlag = true;
                });
                return;
            }
        }
    }
}

