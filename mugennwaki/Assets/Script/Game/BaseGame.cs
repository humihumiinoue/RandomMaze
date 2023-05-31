using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace president
{
    public class BaseGame : MonoBehaviour
    {
        // ゲームの状態
        public enum GameState
        {
            Title,

            Game,

            End,
        }

        public GameState Phase;

        public GameEnd GameEnd{get; set;}

        public DispLayScore dispLayScore{get; set;}

        public int LastScore{get; set;}

        private static BaseGame masterGame;
        public static BaseGame MasterGame{get{return masterGame;} protected set{masterGame = value;}}
    }
}

