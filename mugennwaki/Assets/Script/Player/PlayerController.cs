using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Player
{
    public class PlayerController : BasePlayer
    {
        void Awake()
        {
            MasterPlayer = this.GetComponent<BasePlayer>();
            DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity:800, sequencesCapacity:200);
            InstancePlayer = new InstancePlayer();
            MovePlayer = new MovePlayer();
            PlayerRotate = new PlayerRotate();
            ColPlayer = new ColPlayer();
            PlayerGetItem = new valueObject.PlayerGetItem(0);
            // プレイヤー生成
            InstancePlayer.instancePlayer();
        }

        // Start is called before the first frame update
        void Start()
        {
            // 回転フラグをオン
            MasterPlayer.PlayerRotateFlag = true;
            // 壁に当たった時のアニメーションを再生するフラグをオン
            MasterPlayer.PlayerColWallFlag = true;
        }

        // Update is called once per frame
        void Update()
        {
            // 移動
            MovePlayer.MovePlayerUpdate();
            // 回転
            PlayerRotate.PlayerRotateUpdate();
            // 当たり判定
            ColPlayer.ColPlayerUpdate();
        }

        void OnDestroy()
        {
            DOTween.KillAll();
        }
    }
}
