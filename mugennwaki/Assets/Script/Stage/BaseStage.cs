using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using data;

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
        public bool[,] StandWall{get; protected set;}

        /// <summary>
        /// 迷宮の壁を2次元配列化したもの(生成用)
        /// </summary>
        public GameObject[,] MazeStageArray{get; protected set;}

        /// <summary>
        /// 掘り始める位置X座標
        /// </summary>
        public int DigStartPosW{get; protected set;}

        /// <summary>
        /// 掘り始めるY座標
        /// </summary>
        /// <value></value>
        public int DigStartPosH{get; protected set;}

        /// <summary>
        /// ゴール対象オブジェクト
        /// </summary>
        /// <value></value>
        public GameObject GoalObject{get; protected set;}

        /// <summary>
        /// 上下左右
        /// </summary>
        protected List<Vector3> fourDirections = new List<Vector3>
        { 
            Vector3.up, 
            Vector3.down, 
            Vector3.right, 
            Vector3.left,
        };

        [SerializeField]
        private DataStage dataStage;
        public DataStage DataStageScript{get{return dataStage;}protected set{dataStage = value;}}
    }
}