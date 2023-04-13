using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using System.Linq;

namespace stage
{
    public class StageMaker : BaseStage
    {
        private void Awake()
        {
            initializeMaze();
        }
        
        /// <summary>
        /// 何マスで迷宮を作るか初期宣言・迷宮作成
        /// </summary>
        private void initializeMaze()
        {          

            instanceMaze();

            fixedStartDigPos();

            // ゴール地点の色を赤にする
            GoalObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.red;

            // ゴール地点のオブジェクトをゴールとする
            GoalObject.tag = "Goal";
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void instanceMaze()
        {
            StandWall = new bool[BaseScript.MasterStage.DataStageScript.MazeWidth, BaseScript.MasterStage.DataStageScript.MazeHeight];

            // 縦・幅分のブロックを用意
            MazeStageArray = new GameObject[BaseScript.MasterStage.DataStageScript.MazeWidth, BaseScript.MasterStage.DataStageScript.MazeHeight];

            for (int i = 0; i < BaseScript.MasterStage.DataStageScript.MazeWidth; i++)
            {

                for (int j = 0; j < BaseScript.MasterStage.DataStageScript.MazeHeight; j++)
                {
                    // 壁と床の判定を全マスオン
                    StandWall[i, j] = true;

                    // オブジェクトを全マスに生成
                    MazeStageArray[i, j] = Instantiate(StageObject, new Vector3(i, 0, j)
                    , Quaternion.identity, StageManager.transform) as GameObject;
                }
            }
        }

        /// <summary>
        /// スタート地点をランダムに決定
        /// </summary>
        private void fixedStartDigPos()
        {
            // 横の位置を　0~横幅までの値を返して(Range)    範囲を迷路の端から端に設定
            // iがiのあまり算が0以外の数字を返して(Where)   奇数のみを返す = 外壁の中に生成されるのを防ぐ
            // 適当な値を生成し直して(Guid.NewGuid)
            // 昇順に並び替えて(OrderBy)                   ランダムな順番にする
            // 最初の要素を代入First　
            // iはRangeで返ってきた数字が入る　
            // iはreturn iのこと
            DigStartPosW = Enumerable.Range(0, BaseScript.MasterStage.DataStageScript.MazeWidth)
            .Where(i => (i & 1) != 0)
            .OrderBy(i => Guid.NewGuid())
            .First();

            DigStartPosH = Enumerable.Range(0, BaseScript.MasterStage.DataStageScript.MazeHeight)
            .Where(i => (i & 1) != 0)
            .OrderBy(i => Guid.NewGuid())
            .First();

            // 壁を掘れるかどうか調べる
            checkHitDigWall(new Vector3(DigStartPosW, DigStartPosH, 0));
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
            foreach (var dir in fourDirections.OrderBy(i => Guid.NewGuid()))
            {
                // 2マス先にブロックがないか調べるための計算
                var checkPos = point + dir + dir;

                // 2マス先にブロックがないか調べる
                if (checkInMazePos(checkPos) && StandWall[(int)checkPos.x, (int)checkPos.y])
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
            StandWall[mazeWidth, mazeHeight] = false;

            // すでに消えていないか確認
            if(MazeStageArray[mazeWidth, mazeHeight].transform.GetChild(0).gameObject.activeSelf)
            {
                // 非表示にする
                MazeStageArray[mazeWidth, mazeHeight].transform.GetChild(0).gameObject.SetActive(false);
                // ゴールオブジェクトを更新
                GoalObject = MazeStageArray[mazeWidth, mazeHeight];
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
            && pos.x < BaseScript.MasterStage.DataStageScript.MazeWidth 
            && pos.y < BaseScript.MasterStage.DataStageScript.MazeHeight;
        }
    }
}
