using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BaseStage : MonoBehaviour {

    [SerializeField, Header("床")]
    private GameObject ground;
    [SerializeField, Header("迷宮の壁")]
    private GameObject wallPrefab;
    [SerializeField, Header("カメラ")]
    private Camera mainCamera;

    /// <summary>
    /// 縦
    /// </summary>
    private int mazeHeight;
    /// <summary>
    /// 横
    /// </summary>
    private int mazeWidth;
    /// <summary>
    /// 壁があるかどうかの判定
    /// </summary>
    private bool[,] maze;
    /// <summary>
    /// 迷宮のどの位置の壁か
    /// </summary>
    private GameObject[,] mazeObject;
	/// <summary>
	/// 上下左右
	/// </summary>
	/// <value></value>
    private List<Vector3> searchDirections = new List<Vector3> { Vector3.up, Vector3.down, Vector3.right, Vector3.left,};

    private void Start()
    {
        CreateMaze(21, 21);
    }
	
	/// <summary>
	/// 何マスで迷宮を作るか・迷宮作成
	/// </summary>
	/// <param name="height"></param>
	/// <param name="width"></param>
    private async void CreateMaze(int height, int width)
    {
        mazeWidth = width;
        mazeHeight = height;

        InitializeMaze();

        await DigMaze();
    }

	/// <summary>
	/// 初期設定
	/// </summary>
    private void InitializeMaze()
    {
        maze = new bool[mazeWidth, mazeHeight];
		// 縦・幅分のブロックを用意
        mazeObject = new GameObject[mazeWidth, mazeHeight];
        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
			// 壁判定を全マスオン
                maze[i, j] = true;
			// オブジェクトを全マスに生成
                mazeObject[i, j] = Instantiate(wallPrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
            }
        }

		// 迷路の中心を計算(z,x座標のみ)
        var centered = new Vector3(mazeWidth / 2f - 0.5f, mazeHeight / 2f - 0.5f, 0);
		// 迷路の大きさを設定
        ground.transform.localScale = new Vector3(mazeWidth, mazeHeight, 1);
		// 地面は壁より0.5下に配置
        ground.transform.position = centered + Vector3.back * 0.5f;

		// カメラの位置を設置・全体を見渡す
        mainCamera.transform.position = centered + Vector3.back * ((mazeWidth + mazeHeight) / 2.0f);
    }

	/// <summary>
	/// スタート地点をランダムに決定
	/// </summary>
	/// <returns></returns>
    private async UniTask DigMaze()
    {
		// 横の位置を　0~横幅までの値を返して(Range)　iがiのあまり算が0以外の数字を返して(Where)　適当な値を生成し直して(Guid.NewGuid)　昇順に並び替えて(OrderBy)　最初の要素を代入First　iはRangeで返ってきた数字が入る　iはreturn iのこと
        int startPosW = Enumerable.Range(0, mazeWidth).Where(i => i % 2 != 0).OrderBy(i => Guid.NewGuid()).First();
        int startPosH = Enumerable.Range(0, mazeHeight).Where(i => i % 2 != 0).OrderBy(i => Guid.NewGuid()).First();
        await Dig(new Vector3(startPosW, startPosH, 0));
    }

    /// <summary>
    /// 壁を掘る
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private async UniTask Dig(Vector3 point)
    {
        await RemoveWall(point);
		// 方向のリストをランダムに並び替える
        foreach (var dir in searchDirections.OrderBy(i => Guid.NewGuid())){
            // 2マス先にブロックがないか調べるための計算
            var checkPos = point + dir * 2;
            // 2マス先にブロックがないか調べる
            if (IsInBoard(checkPos) && maze[(int)checkPos.x, (int)checkPos.y])
            {
                await RemoveWall(point + dir);
                await Dig(checkPos);
            }
        }
    }

    /// <summary>
    /// タイミングをずらして掘る
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    private async UniTask RemoveWall(Vector3 point)
    {
        var w = (int)point.x;
        var h = (int)point.y;
        maze[w, h] = false;
        Destroy(mazeObject[w, h]);
        await UniTask.Delay(50);
    }

    /// <summary>
    /// 対象が迷宮の範囲内か調べる
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool IsInBoard(Vector3 pos)
    {
        return pos.x >= 0 && pos.y >= 0 && pos.x < mazeWidth && pos.y < mazeHeight;
    }
}