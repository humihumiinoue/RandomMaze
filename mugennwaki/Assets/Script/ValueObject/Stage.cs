using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace valueObject
{
    public class Stage
    {
    
    }

    /// <summary>
    /// 掘り始める位置X座標
    /// </summary>
    public class DigStartPosW
    {
        public int DigStartPosWidth{get; private set;}

        // コンストラクタ
        public DigStartPosW(int width)
        {
            DigStartPosWidth = width;
        }
    }

    /// <summary>
    /// 掘り始めるY座標
    /// </summary>
    public class DigStartPosH
    {
        public int DigStartPosHeight{get; private set;}

        // コンストラクタ
        public DigStartPosH(int height)
        {
            DigStartPosHeight = height;
        }
    }

    /// <summary>
    /// 迷宮の大きさ
    /// </summary>
    public class MazeSizeX
    {
        public int SizeX{get; private set;}

        // コンストラクタ
        public MazeSizeX(int tmpSize)
        {
            SizeX = tmpSize;
        }
    }
    public class MazeSizeY
    {
        public int SizeY{get; private set;}

        // コンストラクタ
        public MazeSizeY(int tmpSize)
        {
            SizeY = tmpSize;
        }
    }

    /// <summary>
    /// ゲームが始まってプレイヤーが動けるようになるまでの待ち時間
    /// </summary>
    public class StartWaitCount
    {
        public float WaitCount{get; private set;}

        // コンストラクタ
        public StartWaitCount(float tmpCount)
        {
            WaitCount = tmpCount;
        }
    }

    /// <summary>
    /// クリアしたステージ数
    /// </summary>
    public class StageChalengeCount
    {
        public int StageCount{get; private set;}

        // コンストラクタ
        public StageChalengeCount(int tmpCount)
        {
            StageCount = tmpCount;
        }
    }
}
