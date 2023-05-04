using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace data
{
    [CreateAssetMenu(fileName = "StageData", menuName = "SriptableObjects/StageParamAsset")]
    public class DataStage : ScriptableObject
    {
        [SerializeField, Header("迷宮縦マス数(奇数にすること)")]
        private int mazeHeight;
        public int MazeHeight{get{return mazeHeight;}}

        [SerializeField, Header("迷宮横マス数（奇数にすること）")]
        private int mazeWidth;
        public int MazeWidth{get{return mazeWidth;}}

        [SerializeField, Header("ゴールのレイの最大距離")]
        private int goalSeachDirection;
        public int GoalSeachDirection{get{return goalSeachDirection;}}

        [SerializeField, Header("ゲームが始まってプレイヤーが動けるようになるまでの待ち時間")]
        private float waitStartCount;
        public float WaitStartCount{get{return waitStartCount;}}
    }

}
