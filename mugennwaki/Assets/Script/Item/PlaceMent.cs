using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stage;

namespace item
{
    public class PlaceMent
    {
        public void Again()
        {
            
            // シード値を初期化
            uint randomSeed = 0;
            
            // アイテム生成数を初期化
            BaseItem.MasterItem.ItemPop = new valueObject.ItemPop(0);

            for(int i = 0; i < BaseStage.MasterStage.MazeSizeX.SizeX; i++)
            {
                for(int j = 0; j < BaseStage.MasterStage.MazeSizeY.SizeY; j++)
                {
                    // 生成数の上限に達していない
                    if(BaseItem.MasterItem.ItemPop.Count < BaseItem.MasterItem.OverLImit.Number)
                    {
                        randomSeed += (uint)(System.DateTime.Now.Second + 1);

                        // シード値を設定
                        Unity.Mathematics.Random itemRandomObj = new Unity.Mathematics.Random(randomSeed);

                        // 壁がない場所　アイテム生成数が上限に達していない　プレイヤーと同じ位置に出現しない
                        if
                        (BaseItem.MasterItem.Create.ItemInstanceFlag(i, j)
                        
                        && BaseItem.MasterItem.ItemPop.Count < BaseItem.MasterItem.OverLImit.Number)
                        {

                            // 表示する
                            BaseItem.MasterItem.Activation.VisualizationItem
                            (BaseItem.MasterItem.ItemArray[BaseItem.MasterItem.ItemPop.Count]);

                            

                            // 座標を指定して配置
                            BaseItem.MasterItem.ItemArray[BaseItem.MasterItem.ItemPop.Count].transform.position = new Vector3(i, 1, j);

                            
                            
                            // アイテム生成数を増加
                            BaseItem.MasterItem.ItemPop = new valueObject.ItemPop(BaseItem.MasterItem.ItemPop.Count + 1);

                            i++;
                            j++;
                        }
                    }
                }
            }
        }

        
    }
}