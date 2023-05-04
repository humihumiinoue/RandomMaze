using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;
using valueObject;
using DG.Tweening;

namespace goal
{
    public class Goal
    {
        public void GoalUpdate()
        {
            goNextStage();
        }

        // プレイヤーがゴールしたら次のステージへ
        private void goNextStage()
        {
            RaycastHit hit;

            // ゴールオブジェクトにプレイヤーが乗ったら
            if(Physics.Raycast(BaseScript.MasterStage.GoalObject.transform.position,
                            BaseScript.MasterStage.GoalObject.transform.up,
                            out hit,
                            BaseScript.MasterStage.DataStageScript.GoalSeachDirection))
            {
                // ステージクリア後挙動開始フラグ
                BaseScript.MasterStage.StageClearFlag = true;

                // 移動と回転を防ぐ
                BaseScript.MasterPlayer.PlayerRotateFlag = false;
                BaseScript.MasterPlayer.PlayerColWallFlag = false;
                
                // 暗転する
                BaseScript.MasterFade.FadeScene.FadeOutStage();

                // 遅延処理
                DOVirtual.DelayedCall(BaseScript.MasterFade.DataFade.WaitFadeTimer,() =>
                {
                    // スタート位置を再設定
                    BaseScript.MasterPlayer.PlayerObj.transform.position =
                    BaseScript.MasterPlayer.PlayerDefaultPos;

                    // 初めてクリアした
                    if(BaseScript.MasterStage.StageChalengeCount == null)
                    {
                        // クリアしたカウントを記録
                        BaseScript.MasterStage.StageChalengeCount = new StageChalengeCount(1);
                    }
                    else
                    {
                        // 二回目以降のクリアでクリア回数 + 1
                        BaseScript.MasterStage.StageChalengeCount = 
                        new StageChalengeCount(BaseScript.MasterStage.StageChalengeCount.StageCount + 1);
                    }
                    
                    if(BaseScript.MasterStage.StageClearFlag)
                    {
                        // 迷路再生成
                        BaseScript.MasterStage.MakeStage.initializeMaze();
                        BaseScript.MasterStage.StageClearFlag = false;
                    }
                    
                    // 明転する
                    BaseScript.MasterFade.FadeScene.FadeInStage();

                    // 遅延処理
                    DOVirtual.DelayedCall(BaseScript.MasterFade.DataFade.WaitFadeTimer,() =>
                {
                    // 行動可能にする
                    BaseScript.MasterPlayer.PlayerRotateFlag = true;
                    BaseScript.MasterPlayer.PlayerColWallFlag = true;
                    // ステージクリア後挙動開始フラグ
                    BaseScript.MasterStage.StageClearFlag = false;
                } , false);
                } , false);
                    
            }
        }

        // 待機時間
        public async UniTask waitTimer(float waitTimer)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(waitTimer));
        }
    }
}

