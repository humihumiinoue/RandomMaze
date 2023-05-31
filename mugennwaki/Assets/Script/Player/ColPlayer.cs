using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using item;
using Count;


namespace Player
{
    public class ColPlayer
    {

        public void ColPlayerUpdate()
        {
            // 壁との当たり判定
            colToWall();

            // アイテムとの当たり判定
            colToItem();
        }
        
        private void colToWall()
        {
            // 当たり判定の相手・壁
            RaycastHit hitWall;

            // プレイヤーの直線上に壁があるなら
            if(Physics.Raycast(BasePlayer.MasterPlayer.PlayerObj.transform.localPosition
                , BasePlayer.MasterPlayer.PlayerObj.transform.forward
                , out hitWall
                , BasePlayer.MasterPlayer.DataPlayer.PlayerRayMaxDirection))
            {

                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    // 当たり判定先にあるものが壁ならば
                    if(hitWall.collider.CompareTag("Wall")
                    && BasePlayer.MasterPlayer.PlayerMarchFlag
                    && BasePlayer.MasterPlayer.PlayerColWallFlag)
                    {
                        // プレイヤーが壁に当たる挙動
                        BasePlayer.MasterPlayer.MovePlayer.HitWall();
                    }
                }
            }
        }

        // アイテムと当たったら
        private void colToItem()
        {
            // 当たり判定の相手・壁
            RaycastHit hitItem;

            // プレイヤーがアイテムに当たったら
            if(Physics.Raycast(BasePlayer.MasterPlayer.PlayerObj.transform.localPosition
                , BasePlayer.MasterPlayer.PlayerObj.transform.forward
                , out hitItem
                , BasePlayer.MasterPlayer.DataPlayer.PlayerRayMaxDirection / 2)
                
                // アイテムが目の前にあるなら
                && hitItem.collider.gameObject.activeSelf
                
                // 当たり判定先にあるものがアイテムならば
                && hitItem.collider.CompareTag("Item"))
            {
                // アイテムが消える
                BaseItem.MasterItem.Delete.ItemDelete(hitItem.collider.gameObject);

                // アイテム獲得数 +1
                BasePlayer.MasterPlayer.PlayerGetItem = new valueObject.PlayerGetItem(BasePlayer.MasterPlayer.PlayerGetItem.Count + 1);

                // 残り時間増加
                BaseCount.MasterCount.IncremantTime.ExpandTimer();
            }
        }
    }
}
