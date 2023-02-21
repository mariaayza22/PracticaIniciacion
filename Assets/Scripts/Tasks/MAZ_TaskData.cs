using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [System.Serializable]
    public class MAZ_TaskData
    {
        public  List <MAZ_TaskObjective> Objectives = new List <MAZ_TaskObjective>();
        

        public MAZ_TaskData()
        {

        }

        MAZ_TaskData(List<MAZ_TaskObjective> _objs)
        {

        }
    }

  
}

