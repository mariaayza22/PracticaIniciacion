using UnityEngine;
using System.Collections;
using System;

namespace Test
{
    public class MAZ_ObjectGrabbable : MonoBehaviour, IGrabbable
    {
        [SerializeField] protected string m_id;
        /// <summary>
        /// property
        /// </summary>
        public string ID => m_id;
        public Transform m_objectGrabbed;
        [SerializeField] Test.MAZ_Player m_player;



        public void Grab(Transform _objectGrabbed)
        {
            m_objectGrabbed = _objectGrabbed;
            m_objectGrabbed.transform.SetParent(m_player.transform);
        }

       
    }
}



