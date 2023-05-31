using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using president;
using UnityEngine.UI;

namespace Count
{
    public class DispEndScene
    {
        public Text EndSceneScoreText;

        public void DispScene()
        {
            EndSceneScoreText.text = BaseGame.MasterGame.LastScore.ToString() + "階層を踏破!!";
        }
    }
}
