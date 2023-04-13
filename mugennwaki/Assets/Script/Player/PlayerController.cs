using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : BasePlayer
    {
        void Awake()
        {
            InstancePlayerScript = new InstancePlayer();
            MovePlayerScript = new MovePlayer();
            PlayerRotateScript = new PlayerRotate();
            ColPlayerScript = new ColPlayer();
            // プレイヤー生成
            InstancePlayerScript.instancePlayer();
        }

        // Start is called before the first frame update
        void Start()
        {
            // 回転フラグをオン
            BaseScript.MasterPlayer.PlayerRotateFlag = true;
            // 移動フラグをオン
            BaseScript.MasterPlayer.PlayerMarchFlag = true;
            // 壁に当たった時のアニメーションを再生するフラグをオン
            BaseScript.MasterPlayer.PlayerColWallFlag = true;
        }

        // Update is called once per frame
        void Update()
        {
            // 移動
            MovePlayerScript.MovePlayerUpdate();
            // 回転
            PlayerRotateScript.PlayerRotateUpdate();
            // 当たり判定
            ColPlayerScript.ColPlayerUpdate();
        }
    }
}
