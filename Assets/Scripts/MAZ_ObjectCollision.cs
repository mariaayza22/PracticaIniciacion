using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{

    public class MAZ_ObjectCollision : MonoBehaviour
    {
        [SerializeField] protected int m_id;
        /// <summary>
        /// property
        /// </summary>
        public int ID => m_id;
        public Transform m_objectGrabbed;
   
    }

}
