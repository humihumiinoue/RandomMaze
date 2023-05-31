using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Count
{
    public class EndScoreDisp : MonoBehaviour
    {
        

        private DispEndScene dispEndScene;

        

        // Start is called before the first frame update
        void Start()
        {
            dispEndScene = new DispEndScene();

            dispEndScene.EndSceneScoreText = this.GetComponentInChildren<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            dispEndScene.DispScene();
        }
    }
}

