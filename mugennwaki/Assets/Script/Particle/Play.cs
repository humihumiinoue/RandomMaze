using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace particle
{
    public class Play
    {
        public void GoalRightPlaye()
        {
            BaseParticle.MasterParticle.GoalLight.Play();
        }

        public void GoalRightStop()
        {
            BaseParticle.MasterParticle.GoalLight.Stop();
        }
    }
}

