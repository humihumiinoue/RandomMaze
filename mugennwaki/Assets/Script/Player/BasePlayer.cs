using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using data;
using valueObject;

namespace Player
{
    public class BasePlayer : MonoBehaviour
    {
        [SerializeField, Header("プレイヤーまとめ親")]
        protected GameObject parentPlayer;
        public GameObject ParentPlayer{get{return parentPlayer;}}

        /// <summary>
        ///  生成されたプレイヤー・実際に操作する
        /// </summary>
        /// <value></value>
        public GameObject PlayerObj{get; set;}

        /// <summary>
        /// 移動速度
        /// </summary>
        /// <value></value>
        public PlayerRunSpeed PlayerRunSpeed_Z;

        /// <summary>
        /// プレイヤーの初期位置
        /// </summary>
        /// <value></value>
        public Vector3 PlayerDefaultPos{get; set;}

        /// <summary>
        /// 回転可能フラグ
        /// </summary>
        public bool PlayerRotateFlag{get; set;} = false;

        /// <summary>
        /// プレイヤーが移動可能フラグ
        /// </summary>
        public bool PlayerMarchFlag{get; set;} = false;

        /// <summary>
        /// プレイヤーが壁にぶつかるアニメーションが発生するかどうかのフラグ
        /// </summary>
        /// <value></value>
        public bool PlayerColWallFlag{get; set;} = false;

        public Vector3 BeforeMovePlayerPos{get; set;}

        /// <summary>
        /// プレイヤーがゴールした時に移動する距離のクラス
        /// </summary>
        public PlayerGoToNextStage NextStageDirection{get; set;}

        public enum PlayerMoveState
        {
            STOP,
            WALK,
            RUN,
        }

        [SerializeField, Header("プレイヤーの今の状態")]
        protected PlayerMoveState playerMoveState;
        public PlayerMoveState PlayerMoveStates{get{return playerMoveState;} set{playerMoveState = value;}}

        public InstancePlayer InstancePlayer{get; protected set;}

        public MovePlayer MovePlayer{get; protected set;}

        public PlayerRotate PlayerRotate{get; protected set;}

        [SerializeField]
        private DataPlayer scriptablePlayer;
        public DataPlayer DataPlayer{get{return scriptablePlayer;}}

        public ColPlayer ColPlayer{get; protected set;}
    }
}