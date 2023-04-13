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
        /// プレイヤー当たり判定
        /// </summary>
        /// <value></value>
        public Bounds PlayerGoalBounds{get; set;}

        /// <summary>
        /// プレイヤーが壁にぶつかるアニメーションが発生するかどうかのフラグ
        /// </summary>
        /// <value></value>
        public bool PlayerColWallFlag{get; set;} = false;

        public enum PlayerMoveState
        {
            STOP,
            WALK,
            RUN,
        }

        [SerializeField, Header("プレイヤーの今の状態")]
        protected PlayerMoveState playerMoveState;
        public PlayerMoveState PlayerMoveStates{get{return playerMoveState;} set{playerMoveState = value;}}

        public InstancePlayer InstancePlayerScript{get; protected set;}

        public MovePlayer MovePlayerScript{get; protected set;}

        public PlayerRotate PlayerRotateScript{get; protected set;}

        [SerializeField]
        private DataPlayer scriptablePlayer;
        public DataPlayer ScriptablePlayerScript{get{return scriptablePlayer;}}

        public ColPlayer ColPlayerScript{get; protected set;}
    }
}