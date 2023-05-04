using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace stage
{
    public class MakeStage
    {
        /// <summary>
        /// 何マスで迷宮を作るか初期宣言・迷宮作成
        /// </summary>
        public void initializeMaze()
        {          

            instanceMaze();

            fixedStartDigPos();

            // 初期色を登録
            BaseScript.MasterStage.FloorDefaultColor =
            BaseScript.MasterStage.GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color;

            // ゴール地点の色を赤にする
            BaseScript.MasterStage.GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.red;

            // ゴール地点のオブジェクトをゴールとする
            BaseScript.MasterStage.GoalObject.transform.GetChild(1).tag = "Goal";
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void instanceMaze()
        {
            

            // ゲーム起動時は生成・クリア時はアクティブ化
            if(BaseScript.MasterStage.StageChalengeCount == null)
            {
                // 迷宮生成用・ゲーム開始時のみ作用
                StageInstance();
            }
            else
            {
                // 迷宮全マスに対して
                for (int i = 0; i < BaseScript.MasterStage.MazeSizeX.SizeX; i++)
                {

                    for (int j = 0; j < BaseScript.MasterStage.MazeSizeY.SizeY; j++)
                    {
                        // 非アクティブなところだけアクティブ化
                        if(!BaseScript.MasterStage.MazeStageArray[i, j].transform.GetChild(0).gameObject.activeSelf)
                        {
                            BaseScript.MasterStage.MazeStageArray[i, j].transform.GetChild(0).gameObject.SetActive(true);
                            
                            // 壁と床の判定を全マスオン
                            BaseScript.MasterStage.StandWall[i, j] = true;
                            
                        }
                    }
                }
                    // ゴール地点のオブジェクトをただの床にする
                    BaseScript.MasterStage.GoalObject.transform.GetChild(1).tag = "Floor";
                    // ゴール地点の色を元の色にする
                    BaseScript.MasterStage.GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = 
                    BaseScript.MasterStage.FloorDefaultColor;
            }
        }

        // 迷宮生成用・ゲーム開始時のみ作用
        private void StageInstance()
        {
            BaseScript.MasterStage.StandWall = new bool[BaseScript.MasterStage.MazeSizeX.SizeX, 
                                                        BaseScript.MasterStage.MazeSizeY.SizeY];

            // 縦・幅分のブロックを用意
            BaseScript.MasterStage.MazeStageArray = new GameObject[BaseScript.MasterStage.MazeSizeX.SizeX, 
                                                                   BaseScript.MasterStage.MazeSizeY.SizeY];

            for (int i = 0; i < BaseScript.MasterStage.MazeSizeX.SizeX; i++)
            {

                for (int j = 0; j < BaseScript.MasterStage.MazeSizeY.SizeY; j++)
                {
                    // 壁と床の判定を全マスオン
                    BaseScript.MasterStage.StandWall[i, j] = true;

                    // オブジェクトを全マスに生成
                    BaseScript.MasterStage.MazeStageArray[i, j] = MonoBehaviour.Instantiate(
                                                                BaseScript.MasterStage.StageObject, 
                                                                new Vector3(i, 0, j), 
                                                                Quaternion.identity, 
                                                                BaseScript.MasterStage.StageManager.transform) as GameObject;
                }
            }
        }

        /// <summary>
        /// スタート地点をランダムに決定
        /// </summary>
        private void fixedStartDigPos()
        {
            // スタート位置をランダムに決定
            BaseScript.MasterStage.DigStartPosW = new valueObject.DigStartPosW
            (Enumerable.Range(0, BaseScript.MasterStage.MazeSizeX.SizeX)
            .Where(i => (i & 1) != 0)
            .OrderBy(i => Guid.NewGuid())
            .First());

            BaseScript.MasterStage.DigStartPosH = new valueObject.DigStartPosH 
            (Enumerable.Range(0, BaseScript.MasterStage.MazeSizeY.SizeY)
            .Where(i => (i & 1) != 0)
            .OrderBy(i => Guid.NewGuid())
            .First());

            // 壁を掘れるかどうか調べる
            checkHitDigWall(new Vector3(BaseScript.MasterStage.DigStartPosW.DigStartPosWidth, 
                                        BaseScript.MasterStage.DigStartPosH.DigStartPosHeight, 
                                        0));
        }

        /// <summary>
        /// 壁を掘れるかどうか調べる
        /// </summary>
        /// <param name="point">掘る座標</param>
        private void checkHitDigWall(Vector3 point)
        {
            // 壁がない判定にする・非表示にする
            RemoveWall(point);

            // 方向のリストをランダムに並び替える
            foreach (var dir in BaseScript.MasterStage.fourDirections.OrderBy(i => Guid.NewGuid()))
            {
                // 2マス先にブロックがないか調べるための計算
                var checkPos = point + dir + dir;

                // 2マス先にブロックがないか調べる
                if (checkInMazePos(checkPos) && BaseScript.MasterStage.StandWall[(int)checkPos.x, (int)checkPos.y])
                {
                    // 壁がない判定にする・非表示にする
                    RemoveWall(point + dir);

                    // 迷宮の内側かどうかを調べる
                    checkHitDigWall(checkPos);
                }
            }

        }

        /// <summary>
        /// 壁がない判定にする・非表示にする
        /// </summary>
        /// <param name="point">迷路の座標</param>
        private void RemoveWall(Vector3 point)
        {
            var mazeWidth = (int)point.x;
            var mazeHeight = (int)point.y;

            // 壁がない判定にする
            BaseScript.MasterStage.StandWall[mazeWidth, mazeHeight] = false;

            // すでに消えていないか確認
            if(BaseScript.MasterStage.MazeStageArray[mazeWidth, mazeHeight].transform.GetChild(0).gameObject.activeSelf)
            {
                // 非表示にする
                BaseScript.MasterStage.MazeStageArray[mazeWidth, mazeHeight].transform.GetChild(0).gameObject.SetActive(false);
                // ゴールオブジェクトを更新
                BaseScript.MasterStage.GoalObject = BaseScript.MasterStage.MazeStageArray[mazeWidth, mazeHeight];
            }
        }

        /// <summary>
        /// 対象が迷宮の範囲内か調べる
        /// </summary>
        /// <param name="pos">迷宮の範囲内を設定する座標</param>
        private bool checkInMazePos(Vector3 pos)
        {
            return pos.x >= 0 
            && pos.y >= 0 
            && pos.x < BaseScript.MasterStage.MazeSizeX.SizeX
            && pos.y < BaseScript.MasterStage.MazeSizeY.SizeY;
        }
    }

}
