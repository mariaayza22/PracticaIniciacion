using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Test
{
    [System.Serializable]
    public class MAZ_Metrics
    {
        public int CompletedObjective;
        public int FailedObjective;
        public float TimeSpent;

        public void setCompletedObjective(int _completed)
        {
            CompletedObjective = _completed;
        }

        public void setFailedObjective(int _failed)
        {
            FailedObjective = _failed;
        }

        public void setTime(float _time)
        {
            TimeSpent = _time;
        }

    }

}

