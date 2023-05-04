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
        
        private void colToWall()
        {
            // 当たり判定の相手・壁
            RaycastHit hitWall;

            // プレイヤーの直線上に壁があるなら
            if(Physics.Raycast(BaseScript.MasterPlayer.PlayerObj.transform.localPosition
                , BaseScript.MasterPlayer.PlayerObj.transform.forward
                , out hitWall
                , BaseScript.MasterPlayer.DataPlayer.PlayerRayMaxDirection))
            {

                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    // 当たり判定先にあるものが壁ならば
                    if(hitWall.collider.CompareTag("Wall")
                    && BaseScript.MasterPlayer.PlayerMarchFlag
                    && BaseScript.MasterPlayer.PlayerColWallFlag)
                    {
                        BaseScript.MasterPlayer.MovePlayer.HitWall();
                    }
                }
            }
        }
    }
}
