using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SriptableObjects/PlayerParamAsset")]
    public class DataPlayer : ScriptableObject
    {
        [SerializeField, Header("プレイヤーオブジェクト")]
        private GameObject playerPrefab;
        public GameObject PlayerPrefab{get{return playerPrefab;}}

        [SerializeField, Header("回転時間")]
        private float rotateSpeed;
        public float RotateSpeed{get{return rotateSpeed;}}

        [SerializeField, Header("前進時間")]
        private float marchSpeed;
        public float MarchSpeed{get{return marchSpeed;}}

        [SerializeField, Header("Rayの最大距離")]
        private float playerRayMaxDirection;
        public float PlayerRayMaxDirection{get{return playerRayMaxDirection;}}

        [SerializeField, Header("壁に衝突した時の反動によって跳ぶ大きさ")]
        private float hitWallJumpPower;
        public float HitWallJumpPower{get{return hitWallJumpPower;}}

        [SerializeField, Header("壁に移動する距離")]
        private int moveDirection;
        public int MoveDirection{get{return moveDirection;}}

    }
}

