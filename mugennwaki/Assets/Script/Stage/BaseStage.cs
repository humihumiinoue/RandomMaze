using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stage
{
    public class BaseStage : MonoBehaviour 
    {

        [SerializeField, Header("床")]
        protected GameObject floor;
        public GameObject Floor{get{return floor;}protected set{floor = value;}}
        [SerializeField, Header("迷宮の壁")]
        protected GameObject wallPrefab;
        public GameObject WallPrefab{get{return wallPrefab;}protected set{wallPrefab = value;}}

        
        private int mazeHeight;
        /// <summary>
        /// 縦
        /// </summary>
        public int MazeHeight{get{return mazeHeight;}protected set{mazeHeight = value;}}
        protected int mazeWidth;
        /// <summary>
        /// 横
        /// </summary>
        public int MazeWidth{get{return mazeWidth;}protected set{mazeWidth = value;}}
        protected bool[,] maze;
        /// <summary>
        /// 壁があるかどうかの判定
        /// </summary>
        public bool[,] Maze{get{return maze;}protected set{maze = value;}}
        protected GameObject[,] mazeWallObject;
        /// <summary>
        /// 迷宮の壁を2次元配列化したもの(生成用)
        /// </summary>
        public GameObject[,] MazeWallObject{get{return mazeWallObject;}protected set{mazeWallObject = value;}}
        /// <summary>
        /// 生成用オブジェクト
        /// </summary>
        protected GameObject mazeFloorObject;
        public GameObject MazeFloorObject{get{return mazeFloorObject;}protected set{mazeFloorObject = value;}}
        /// <summary>
        /// 1マス掘るのにかかる時間(1/1000s)
        /// </summary>
        protected const int DIG_TIME = 40;
        protected Vector3 centered;
        /// <summary>
        /// 迷路の中心を計算(x,y座標のみ)
        /// </summary>
        public Vector3 Centered{get{return centered;} protected set{centered = value;}}
        /// <summary>
        /// 上下左右
        /// </summary>
        /// <value></value>
        protected List<Vector3> searchDirections = new List<Vector3> { Vector3.up, Vector3.down, Vector3.right, Vector3.left,};

    }
}