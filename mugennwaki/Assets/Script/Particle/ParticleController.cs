using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using stage;

namespace particle
{
    public class ParticleController : BaseParticle
    {
        // Start is called before the first frame update
        void Start()
        {
            MasterParticle = this.GetComponent<BaseParticle>();
            Play = new Play();

            // ゴールに位置に光を配置
            GoalLight.transform.localPosition = BaseStage.MasterStage.GoalObject.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}
