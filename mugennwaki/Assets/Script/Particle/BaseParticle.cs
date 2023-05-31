using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace particle
{
    public class BaseParticle : MonoBehaviour
    {
        [SerializeField, Header("ゴール地点の光")]
        private ParticleSystem goalLight;
        public ParticleSystem GoalLight{get{return goalLight;} set{goalLight = value;}}

        private static BaseParticle masterParticle;
        public static BaseParticle MasterParticle{get{return masterParticle;} set{masterParticle = value;}}
        public Play Play{get; set;}
    }
}

