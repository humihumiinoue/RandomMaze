using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace load
{
    public class LoadController : BaseLoad
    {
        // Start is called before the first frame update
        void Start()
        {
            if(MasterLoad == null)
            {
                MasterLoad = this.GetComponent<BaseLoad>();
            }
            else
            {
                Destroy(this);
            }
            
            Move = new Move();
            DontDestroyOnLoad(LoadManager);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

