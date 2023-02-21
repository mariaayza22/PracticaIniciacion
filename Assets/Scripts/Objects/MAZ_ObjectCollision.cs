using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{

    public class MAZ_ObjectCollision : MonoBehaviour
    {
        [SerializeField] protected string m_id;
        /// <summary>
        /// property
        /// </summary>
        public string ID => m_id;
        public Transform m_objectGrabbed;
   
    }

}
