using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class MAZ_Debugger : MonoBehaviour
    {
        [SerializeField] private GameObject[] m_managersToActivate;

        private void Awake()
        {
            if (!MAZ_AudioManager.Instance)
            {
                foreach (var manager in m_managersToActivate)
                {
                    manager.SetActive(true);
                }
            }
        }
    }
}
