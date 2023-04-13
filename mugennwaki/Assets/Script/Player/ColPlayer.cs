using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public class ColPlayer
    {
        public void ColPlayerUpdate()
        {
            colToWall();
        }

        // todo:連打防止
        private void colToWall()
        {
            // 当たり判定の相手・壁
            RaycastHit hitWall;

            Vector3 tmpPlayerPos = BaseScript.MasterPlayer.PlayerObj.transform.position;

            
            // プレイヤーの直線上に壁があるなら
            if(Physics.Raycast(BaseScript.MasterPlayer.PlayerObj.transform.localPosition
                , BaseScript.MasterPlayer.PlayerObj.transform.forward
                , out hitWall
                , BaseScript.MasterPlayer.ScriptablePlayerScript.PlayerRayMaxDirection))
            {

                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    // 当たり判定先にあるものが壁ならば
                    if(hitWall.collider.CompareTag("Wall")
                    && BaseScript.MasterPlayer.PlayerMarchFlag
                    && BaseScript.MasterPlayer.PlayerColWallFlag)
                    {
                        
                        // 壁に進む
                        BaseScript.MasterPlayer.PlayerObj.transform.DOMove(
                            BaseScript.MasterPlayer.PlayerObj.transform.forward 
                            / BaseScript.MasterPlayer.ScriptablePlayerScript.MoveDirection
                            , BaseScript.MasterPlayer.ScriptablePlayerScript.MarchSpeed
                            , false
                        )
                        .SetRelative(true)
                        .OnStart(() => 
                        {
                            // 壁に当たって跳ね返るアニメーションのフラグをオフ
                            BaseScript.MasterPlayer.PlayerColWallFlag = false;
                        })
                        .OnComplete(() =>
                        {
                            // 壁にぶつかって後ろにはじかれる
                            BaseScript.MasterPlayer.PlayerObj.transform.DOJump(
                                -BaseScript.MasterPlayer.PlayerObj.transform.forward 
                                / BaseScript.MasterPlayer.ScriptablePlayerScript.MoveDirection
                                , BaseScript.MasterPlayer.ScriptablePlayerScript.HitWallJumpPower
                                , 1
                                , BaseScript.MasterPlayer.ScriptablePlayerScript.MarchSpeed
                                , false
                            )
                            .SetRelative(true)
                            .OnComplete(() =>
                            {
                                // 位置を矯正
                                BaseScript.MasterPlayer.PlayerObj.transform.position =
                                tmpPlayerPos;

                                // 壁に当たって跳ね返るアニメーションのフラグをオン
                                BaseScript.MasterPlayer.PlayerColWallFlag = true;
                            });
                        });
                    }
                }
            }
        }
    }
}
