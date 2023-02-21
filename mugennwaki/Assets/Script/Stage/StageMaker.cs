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
        private void Start()
        {
            CreateMaze();
        }
        
        /// <summary>
        /// 何マスで迷宮を作るか初期宣言・迷宮作成
        /// </summary>
        private async void CreateMaze()
        {
            // 外壁は奇数にすること
            MazeWidth = 29;
            MazeHeight = 29;

            // 横と縦の半分
            Centered = new Vector3((MazeWidth >> 1), (MazeHeight >> 1), 0);

            InitializeMaze();

            await DigMaze();
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        private void InitializeMaze()
        {
            Maze = new bool[MazeWidth, MazeHeight];
            // 縦・幅分のブロックを用意
            MazeWallObject = new GameObject[MazeWidth, MazeHeight];
            for (int i = 0; i < MazeWidth; i++)
            {
                for (int j = 0; j < MazeHeight; j++)
                {
                // 壁判定を全マスオン
                    Maze[i, j] = true;
                // オブジェクトを全マスに生成
                    MazeWallObject[i, j] = Instantiate(WallPrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                }
            }
            // 迷路の床の大きさを設定
            Floor.transform.localScale = new Vector3(MazeWidth, MazeHeight, 1);
            // 地面は壁より下に配置
            Vector3 floorPos = Centered + Vector3.forward;
            // 床を迷路と同じ大きさで真ん中に生成
            MazeFloorObject = Instantiate(Floor, floorPos, Quaternion.identity) as GameObject;
        }

        /// <summary>
        /// スタート地点をランダムに決定
        /// </summary>
        private async UniTask DigMaze()
        {
            // 横の位置を　0~横幅までの値を返して(Range)    範囲を迷路の端から端に設定
            // iがiのあまり算が0以外の数字を返して(Where)   奇数のみを返す = 外壁の中に生成されるのを防ぐ
            // 適当な値を生成し直して(Guid.NewGuid)
            // 昇順に並び替えて(OrderBy)                   ランダムな順番にする
            // 最初の要素を代入First　
            // iはRangeで返ってきた数字が入る　
            // iはreturn iのこと
            int startPosW = Enumerable.Range(0, MazeWidth).Where(i => (i & 1) != 0).OrderBy(i => Guid.NewGuid()).First();
            int startPosH = Enumerable.Range(0, MazeHeight).Where(i => (i & 1) != 0).OrderBy(i => Guid.NewGuid()).First();
            await Dig(new Vector3(startPosW, startPosH, 0));
        }

        /// <summary>
        /// 壁を掘る
        /// </summary>
        /// <param name="point">掘る座標</param>
        private async UniTask Dig(Vector3 point)
        {
            await RemoveWall(point);
            // 方向のリストをランダムに並び替える
            foreach (var dir in searchDirections.OrderBy(i => Guid.NewGuid())){
                // 2マス先にブロックがないか調べるための計算
                var checkPos = point + dir * 2;
                // 2マス先にブロックがないか調べる
                if (IsInBoard(checkPos) && Maze[(int)checkPos.x, (int)checkPos.y])
                {
                    await RemoveWall(point + dir);
                    await Dig(checkPos);
                }
            }
        }

        /// <summary>
        /// タイミングをずらして掘る
        /// </summary>
        /// <param name="point">迷路の座標</param>
        private async UniTask RemoveWall(Vector3 point)
        {
            var w = (int)point.x;
            var h = (int)point.y;
            Maze[w, h] = false;
            MazeWallObject[w, h].SetActive(false);
            await UniTask.Delay(DIG_TIME);
        }

        /// <summary>
        /// 対象が迷宮の範囲内か調べる
        /// </summary>
        /// <param name="pos">迷宮の範囲内を設定する座標</param>
        private bool IsInBoard(Vector3 pos)
        {
            return pos.x >= 0 && pos.y >= 0 && pos.x < MazeWidth && pos.y < MazeHeight;
        }
    }
}
