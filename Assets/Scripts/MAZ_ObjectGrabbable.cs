using UnityEngine;
using System.Collections;

namespace Test
{
    public class MAZ_ObjectGrabbable : MonoBehaviour, IGrabbable
    {
        [SerializeField] protected int m_id;
        /// <summary>
        /// property
        /// </summary>
        public int ID => m_id;
        public Transform m_objectGrabbed;
        [SerializeField] Test.MAZ_Player m_player;


        public void Grab(Transform objectGrabbed)
        {
            m_objectGrabbed = objectGrabbed;
            m_objectGrabbed.transform.SetParent(m_player.transform);
        }
    }
}



