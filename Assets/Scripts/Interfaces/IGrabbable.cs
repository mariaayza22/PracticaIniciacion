using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public interface IGrabbable
    {
        public string ID { get; }
        public void Grab(Transform objectGrabbed);
    }
}


