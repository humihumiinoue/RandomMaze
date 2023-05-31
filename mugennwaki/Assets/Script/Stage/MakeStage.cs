using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using president;

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
            BaseStage.MasterStage.FloorDefaultColor =
            BaseStage.MasterStage.GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color;

            // ゴール地点の色を赤にする
            BaseStage.MasterStage.GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.red;

            // ゴール地点のオブジェクトをゴールとする
            BaseStage.MasterStage.GoalObject.transform.GetChild(1).tag = "Goal";

            // メインゲームにステートを変える
            BaseGame.MasterGame.Phase = BaseGame.GameState.Game;
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void instanceMaze()
        {
            

            // ゲーム起動時は生成・クリア時はアクティブ化
            if(BaseStage.MasterStage.StageChalengeCount.StageCount == 0)
            {
                // 迷宮生成用・ゲーム開始時のみ作用
                StageInstance();
            }
            else
            {
                // 迷宮全マスに対して
                for (int i = 0; i < BaseStage.MasterStage.MazeSizeX.SizeX; i++)
                {

                    for (int j = 0; j < BaseStage.MasterStage.MazeSizeY.SizeY; j++)
                    {
                        // 非アクティブなところだけアクティブ化
                        if(!BaseStage.MasterStage.MazeStageArray[i, j].transform.GetChild(0).gameObject.activeSelf)
                        {
                            BaseStage.MasterStage.MazeStageArray[i, j].transform.GetChild(0).gameObject.SetActive(true);
                            
                            // 壁と床の判定を全マスオン
                            BaseStage.MasterStage.StandWall[i, j] = true;
                            
                        }
                    }
                }

                // ゴール地点のオブジェクトをただの床にする
                BaseStage.MasterStage.GoalObject.transform.GetChild(1).tag = "Floor";
                // ゴール地点の色を元の色にする
                BaseStage.MasterStage.GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = 
                BaseStage.MasterStage.FloorDefaultColor;

                
            }
        }

        // 迷宮生成用・ゲーム開始時のみ作用
        private void StageInstance()
        {
            BaseStage.MasterStage.StandWall = new bool[BaseStage.MasterStage.MazeSizeX.SizeX, 
                                                        BaseStage.MasterStage.MazeSizeY.SizeY];

            // 縦・幅分のブロックを用意
            BaseStage.MasterStage.MazeStageArray = new GameObject[BaseStage.MasterStage.MazeSizeX.SizeX, 
                                                                   BaseStage.MasterStage.MazeSizeY.SizeY];

            for (int i = 0; i < BaseStage.MasterStage.MazeSizeX.SizeX; i++)
            {

                for (int j = 0; j < BaseStage.MasterStage.MazeSizeY.SizeY; j++)
                {
                    // 壁と床の判定を全マスオン
                    BaseStage.MasterStage.StandWall[i, j] = true;

                    // オブジェクトを全マスに生成
                    BaseStage.MasterStage.MazeStageArray[i, j] = MonoBehaviour.Instantiate(
                                                                BaseStage.MasterStage.StageObject, 
                                                                new Vector3(i, 0, j), 
                                                                Quaternion.identity, 
                                                                BaseStage.MasterStage.StageManager.transform) as GameObject;
                }
            }
        }

        /// <summary>
        /// スタート地点をランダムに決定
        /// </summary>
        private void fixedStartDigPos()
        {
            // スタート位置をランダムに決定
            BaseStage.MasterStage.DigStartPosW = new valueObject.DigStartPosW
            (Enumerable.Range(0, BaseStage.MasterStage.MazeSizeX.SizeX)
            .Where(i => (i & 1) != 0)
            .OrderBy(i => Guid.NewGuid())
            .First());

            BaseStage.MasterStage.DigStartPosH = new valueObject.DigStartPosH 
            (Enumerable.Range(0, BaseStage.MasterStage.MazeSizeY.SizeY)
            .Where(i => (i & 1) != 0)
            .OrderBy(i => Guid.NewGuid())
            .First());

            // 壁を掘れるかどうか調べる
            checkHitDigWall(new Vector3(BaseStage.MasterStage.DigStartPosW.DigStartPosWidth, 
                                        BaseStage.MasterStage.DigStartPosH.DigStartPosHeight, 
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
            foreach (var dir in BaseStage.MasterStage.fourDirections.OrderBy(i => Guid.NewGuid()))
            {
                // 2マス先にブロックがないか調べるための計算
                var checkPos = point + dir + dir;

                // 2マス先にブロックがないか調べる
                if (checkInMazePos(checkPos) && BaseStage.MasterStage.StandWall[(int)checkPos.x, (int)checkPos.y])
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
            BaseStage.MasterStage.StandWall[mazeWidth, mazeHeight] = false;

            // すでに消えていないか確認
            if(BaseStage.MasterStage.MazeStageArray[mazeWidth, mazeHeight].transform.GetChild(0).gameObject.activeSelf)
            {
                // 非表示にする
                BaseStage.MasterStage.MazeStageArray[mazeWidth, mazeHeight].transform.GetChild(0).gameObject.SetActive(false);
                // ゴールオブジェクトを更新
                BaseStage.MasterStage.GoalObject = BaseStage.MasterStage.MazeStageArray[mazeWidth, mazeHeight];
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
            && pos.x < BaseStage.MasterStage.MazeSizeX.SizeX
            && pos.y < BaseStage.MasterStage.MazeSizeY.SizeY;
        }
    }

}
