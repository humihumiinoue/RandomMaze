using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace load
{
    public class Move
    {
        public void LoadScene(int tmpSceneNumber)
        {
            SceneManager.LoadSceneAsync(tmpSceneNumber);
        }
    }
}

