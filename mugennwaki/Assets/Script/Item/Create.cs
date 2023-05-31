using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stage;
using Player;

namespace item
{
    public class Create
    {
        public void InstanceUpdate()
        {
            
            setItem();
                
        }

        // アイテム生成
        private void setItem()
        {
            uint randomSeed = 0;

            
            for(int i = 0; i < BaseStage.MasterStage.MazeSizeX.SizeX; i++)
            {
                for(int j = 0; j < BaseStage.MasterStage.MazeSizeY.SizeY; j++)
                {
                    
                    randomSeed += (uint)(System.DateTime.Now.Second + 1);

                    // ほぼ被りなしでシード値を設定
                    Unity.Mathematics.Random itemRandomObj = new Unity.Mathematics.Random(randomSeed);

                    // 壁がない場所　アイテム生成数が上限に達していない　プレイヤーと同じ位置に出現しない
                    if
                    (ItemInstanceFlag(i, j)
                    
                    && BaseItem.MasterItem.ItemPop.Count < BaseItem.MasterItem.OverLImit.Number)
                    {
                        // アイテム生成数を増加
                        BaseItem.MasterItem.ItemPop = new valueObject.ItemPop(BaseItem.MasterItem.ItemPop.Count + 1);

                        BaseItem.MasterItem.ItemObject = MonoBehaviour.Instantiate(
                                                                        BaseItem.MasterItem.DataItem.ItemPrefab
                                                                        , new Vector3(i, 1, j)
                                                                        , Quaternion.identity
                                                                        , BaseItem.MasterItem.ItemManager.transform);
                        
                        j++;
                        i++;
                        
                    }
                }
            }
            
        }

        /// <summary>
        /// アイテム生成条件
        /// </summary>
        /// <param name="tmpNum"></param>
        /// <param name="tmpRandom">乱数</param>
        /// <returns></returns>
        public bool RandomNumberThroew(int tmpNum, Unity.Mathematics.Random tmpRandom)
        {
            return BaseStage.MasterStage.MazeSizeX.SizeX * BaseStage.MasterStage.MazeSizeY.SizeY
                    % 
                    tmpRandom.NextInt(1, BaseStage.MasterStage.MazeSizeX.SizeX * BaseStage.MasterStage.MazeSizeY.SizeY) == tmpNum;
        }

        /// <summary>
        /// アイテム生成条件
        /// </summary>
        /// <param name="tmpi">迷宮の縦マス数</param>
        /// <param name="tmpj">迷宮の横マス数</param>
        public bool ItemInstanceFlag(int tmpi, int tmpj)
        {           
            // アイテム生成座標
            Vector3 itemPos = new Vector3(tmpi, 0, tmpj);

                    // 壁がない
            return (!BaseStage.MasterStage.StandWall[tmpi , tmpj]

                    // プレイヤーと同じマスに出現しない
                    && BasePlayer.MasterPlayer.PlayerObj.transform.position != itemPos

                    // ゴールと同じマスに出現しない
                    && BaseStage.MasterStage.GoalObject.transform.position != itemPos

                    // 迷宮の範囲内である
                    && tmpi != BaseStage.MasterStage.DigStartPosW.DigStartPosWidth

                    // 迷宮の範囲内である
                    && tmpj != BaseStage.MasterStage.DigStartPosH.DigStartPosHeight);
        }
    }
}
