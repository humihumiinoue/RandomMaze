using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using load;
using stage;

namespace president
{
    public class GameController : BaseGame
    {
        // Start is called before the first frame update
        void Start()
        {
            if(MasterGame == null)
            {
                MasterGame = this.GetComponent<BaseGame>();
            }
            else
            {
                Destroy(this);
            }
            

            GameEnd = new GameEnd();

            dispLayScore = new DispLayScore();

            DontDestroyOnLoad(MasterGame);
        }

        // Update is called once per frame
        void Update()
        {
            

            switch(Phase)
            {
                case GameState.Title:

                if(Input.GetKeyDown(KeyCode.Return))
                {
                    BaseLoad.MasterLoad.Move.LoadScene((int)BaseGame.GameState.Game);
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }

                break;

                case GameState.Game:

                // スコア表示
                dispLayScore.DispLayFloor();

                GameEnd.Finish();

                // 時間切れ
                if(Phase == BaseGame.GameState.End)
                {
                    LastScore = BaseStage.MasterStage.StageChalengeCount.StageCount;
                    BaseLoad.MasterLoad.Move.LoadScene((int)BaseGame.GameState.End);
                }
                break;

                case GameState.End:

                // ゲームもう一度
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    BaseLoad.MasterLoad.Move.LoadScene((int)BaseGame.GameState.Game);
                    Phase = GameState.Game;
                }
                // タイトルへ
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    BaseLoad.MasterLoad.Move.LoadScene((int)BaseGame.GameState.Title);
                    Phase = GameState.Title;
                }
                
                break;
            }
        }
    }
}

