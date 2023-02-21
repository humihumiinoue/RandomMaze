using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using camera;
using stage;

public class BaseBase : MonoBehaviour
{
    public static BaseCamera TmpCamera{get; private set;}
    public static BaseStage TmpStage{get; private set;}

    void Start()
    {
        TmpCamera = GameObject.FindWithTag("MainCamera").GetComponent<BaseCamera>();
        TmpStage = GameObject.FindWithTag("Stage").GetComponent<BaseStage>();
    }
}
