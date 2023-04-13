using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using camera;
using stage;
using Player;

public class BaseScript : MonoBehaviour
{
    public static BaseCamera MasterCamera{get; private set;}
    public static BaseStage MasterStage{get; private set;}
    public static BasePlayer MasterPlayer{get; private set;}

    // TODO:Unitask非同期・ステージ生成が終わるまで待つ
    void Awake()
    {
        MasterCamera = GameObject.Find("Main Camera").GetComponent<BaseCamera>();
        MasterStage = GameObject.Find("StageManager").GetComponent<BaseStage>();
        MasterPlayer = GameObject.Find("PlayerManager").GetComponent<BasePlayer>();
    }
}
