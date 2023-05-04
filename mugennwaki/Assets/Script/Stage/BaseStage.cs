using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using data;
using valueObject;
using goal;

namespace stage
{
    public class BaseStage : MonoBehaviour 
    {
        
        [SerializeField, Header("壁と床オブジェクトのまとめ親")]
        protected GameObject stageObjecto;
        public GameObject StageObject{get{return stageObjecto;}}

        [SerializeField, Header("壁と床オブジェクトのまとめ親の親")]
        protected GameObject stageManager;
        public GameObject StageManager{get{return stageManager;}}


        /// <summary>
        /// 壁があるかどうかの判定
        /// </summary>
        public bool[,] StandWall{get; set;}

        /// <summary>
        /// 迷宮の壁を2次元配列化したもの(生成用)
        /// </summary>
        public GameObject[,] MazeStageArray{get; set;}
        
        /// <summary>
        /// ゴール対象オブジェクト
        /// </summary>
        /// <value></value>
        public GameObject GoalObject{get; set;}

        /// <summary>
        /// 掘り始める位置X座標
        /// </summary>
        public DigStartPosW DigStartPosW{get; set;}

        /// <summary>
        /// 掘り始めるY座標
        /// </summary>
        /// <value></value>
        public DigStartPosH DigStartPosH{get; set;}

        /// <summary>
        /// 暗転時間クラス
        /// </summary>
        /// <value></value>
        public FadeTimer FadeTimer{get; set;}

        /// <summary>
        /// ゲームが始まってプレイヤーが動けるようになるまでの待ち時間クラス
        /// </summary>
        /// <value></value>
        public StartWaitCount StartWaitCount{get; set;}

        /// <summary>
        /// クリアしたステージ数
        /// </summary>
        /// <value></value>
        public StageChalengeCount StageChalengeCount{get; set;}

        /// <summary>
        /// 迷宮の大きさ
        /// </summary>
        /// <value></value>
        public MazeSizeX MazeSizeX{get; set;}
        public MazeSizeY MazeSizeY{get; set;}

        /// <summary>
        /// ゴールオブジェクトのカラー
        /// </summary>
        public Color FloorDefaultColor{get{return floorDefaultColor;} set{floorDefaultColor = value;}}
        private Color floorDefaultColor;

        /// <summary>
        /// ステージクリア後挙動開始フラグ
        /// </summary>
        public bool StageClearFlag;

        /// <summary>
        /// 上下左右
        /// </summary>
        [System.NonSerialized]
        public List<Vector3> fourDirections = new List<Vector3>
        { 
            Vector3.up, 
            Vector3.down, 
            Vector3.right, 
            Vector3.left,
        };

        [SerializeField]
        private DataStage dataStage;
        public DataStage DataStageScript{get{return dataStage;}protected set{dataStage = value;}}

        public MakeStage MakeStage{get; protected set;}

        public Goal Goal{get; protected set;}
    }
}