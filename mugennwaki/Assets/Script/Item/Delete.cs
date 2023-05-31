using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace item
{
    public class Delete
    {
        public void ItemDelete(GameObject tmpItem)
        {
            tmpItem.SetActive(false);
        }
    }
}
