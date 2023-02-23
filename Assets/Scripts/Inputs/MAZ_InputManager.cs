
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test
{
    public class MAZ_InputManager : MonoBehaviour
    {
        public enum INPUT_SYSTEM_TYPE
        {
            OLD,
            NEW
        }

        private static MAZ_InputManager m_instance;

        public static MAZ_InputManager Instance => m_instance;

        [SerializeField] private INPUT_SYSTEM_TYPE m_currentInputSystem = INPUT_SYSTEM_TYPE.NEW;
        [SerializeField] private InputActionAsset m_controls;

        private InputActionMap m_playerActions;

        public bool UseNewInputSystem => m_currentInputSystem == INPUT_SYSTEM_TYPE.NEW;

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
                m_playerActions = m_controls.FindActionMap("Player");
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public float GetHorizontalAxis()
        {
            if (!UseNewInputSystem)
            {
                return Input.GetAxis("Horizontal");
            }

            return m_playerActions.FindAction("Move").ReadValue<Vector3>().x;
        }

        public float GetVerticalAxis()
        {
            if (!UseNewInputSystem)
            {
                return Input.GetAxis("Vertical");
            }

            return m_playerActions.FindAction("Move").ReadValue<Vector3>().z;
        }

        public bool IsMousePressed()
        {
            if (!UseNewInputSystem)
            {
                return Input.GetMouseButtonDown(0);
            }
            return m_playerActions.FindAction("Grab").IsInProgress();
        }

        public bool IsSpacePressed()
        {
            if (!UseNewInputSystem)
            {
                return Input.GetKeyDown(KeyCode.Space);
            }
            return m_playerActions.FindAction("Release").IsInProgress();
        }

        public float GetMouseX()
        {
            if (!UseNewInputSystem)
            {
                return Input.GetAxis("Mouse X");
            }
            return m_playerActions.FindAction("Look").ReadValue<Vector3>().x;
        }

        public float GetMouseY()
        {
            if (!UseNewInputSystem)
            {
                return Input.GetAxis("Mouse Y");
            }
            return m_playerActions.FindAction("Look").ReadValue<Vector3>().y;
        }

    }
}
