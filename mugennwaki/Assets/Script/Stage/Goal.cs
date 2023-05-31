using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;
using valueObject;
using stage;
using Player;
using fade;
using item;
using particle;

namespace goal
{
    public class Goal
    {
        public void GoalUpdate()
        {
            goNextStage();
        }

        // プレイヤーがゴールしたら次のステージへ
        private async void goNextStage()
        {
            RaycastHit hit;

            // ゴールオブジェクトにプレイヤーが乗ったら　・　アイテムをすべて回収したら
            if(Physics.Raycast(BaseStage.MasterStage.GoalObject.transform.position,
                            BaseStage.MasterStage.GoalObject.transform.up,
                            out hit,
                            BaseStage.MasterStage.DataStageScript.GoalSeachDirection)

                && BasePlayer.MasterPlayer.PlayerGetItem.Count ==
                BaseItem.MasterItem.OverLImit.Number)
            {
                // 獲得数を初期化
                BasePlayer.MasterPlayer.PlayerGetItem = new valueObject.PlayerGetItem(0);

                // ステージクリア後挙動開始フラグ
                BaseStage.MasterStage.StageClearFlag = true;

                // 移動と回転を防ぐ
                BasePlayer.MasterPlayer.PlayerRotateFlag = false;
                BasePlayer.MasterPlayer.PlayerColWallFlag = false;
                
                // 暗転する
                BaseFade.MasterFade.FadeScene.FadeOutStage();

                // 暗転するまで遅延
                await UniTask.Delay((int)(BaseFade.MasterFade.DataFade.WaitFadeTimer * 1000));

                // ゴールの光を止める
                BaseParticle.MasterParticle.Play.GoalRightStop();

                // アイテム所持数を初期化
                BasePlayer.MasterPlayer.PlayerGetItem = new PlayerGetItem(0);

                // クリアした回数を数える
                incrementCrearCount();
                

                // ステージを再生成する
                reinstanceStage();

                // スタート位置を再設定
                BasePlayer.MasterPlayer.PlayerObj.transform.position =
                BasePlayer.MasterPlayer.PlayerDefaultPos;

                

                // アイテムを再配置する
                BaseItem.MasterItem.PlaceMent.Again();

                // ゴールの位置に光を配置
                BaseParticle.MasterParticle.GoalLight.transform.position = BaseStage.MasterStage.GoalObject.transform.position;

                // ゴールに光りを刺す
                BaseParticle.MasterParticle.Play.GoalRightPlaye();
                
                // 明転する
                BaseFade.MasterFade.FadeScene.FadeInStage();

                
                // 行動可能にする
                BasePlayer.MasterPlayer.PlayerRotateFlag = true;
                BasePlayer.MasterPlayer.PlayerColWallFlag = true;
                
                // ステージクリア後挙動開始フラグ
                BaseStage.MasterStage.StageClearFlag = false;
                
            }
        }

        private void incrementCrearCount()
        {
            
            // 二回目以降のクリアでクリア回数 + 1
            BaseStage.MasterStage.StageChalengeCount = 
            new StageChalengeCount(BaseStage.MasterStage.StageChalengeCount.StageCount + 1);
            
        }

        // 再生成まとめ
        private void reinstanceStage()
        {
            if(BaseStage.MasterStage.StageClearFlag)
            {
                // 迷路再生成
                BaseStage.MasterStage.MakeStage.initializeMaze();

                // 複数回生成されるのを防ぐ
                BaseStage.MasterStage.StageClearFlag = false;
            }
        }

        // 待機時間
        public async UniTask waitTimer(float waitTimer)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(waitTimer));
        }
    }
}

