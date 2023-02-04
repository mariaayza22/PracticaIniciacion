using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public interface IGrabbable
    {
        public int ID { get; }
        public void Grab(Transform objectGrabbed);
    }
}


