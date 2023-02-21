using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class MAZ_Area : MonoBehaviour
    {
        
        [SerializeField] protected string m_id;
        public string ID => m_id;
        private MAZ_ObjectGrabbable m_objectGrabbed;
        
        

        private void OnTriggerEnter(Collider _other)
        {

            if(_other.tag.Equals("grabbableObj") && _other.gameObject.transform.TryGetComponent<Test.MAZ_ObjectGrabbable>(out Test.MAZ_ObjectGrabbable _objG))
            {
                m_objectGrabbed = _objG;
                Debug.Log(m_objectGrabbed.ID);
                Debug.Log(ID);  
            }
            else
            {
                Debug.Log("algo no ha funcionao");
            }
            MAZ_TaskManager.Instance.CheckObjective(ID, m_objectGrabbed.ID);
        }


        private void OnTriggerExit(Collider _other)
        {
            if (_other.tag.Equals("grabbableObj"))
            {
                Debug.Log("You've exited the area");
            }
        }

    }

}
