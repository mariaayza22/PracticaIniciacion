using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class MAZ_MouseLook : MonoBehaviour
    {
        //Control the speed of our mouse. 
        public float m_mouseSensitivity = 100f;

        //Reference of our main camera to our entire first person player object so that we can rotate ir around.
        public Transform m_playerBody;

        float m_xRotation = 0f;
        private Graphics m_pointCenter;
        private Color m_objCentered;

        private MAZ_InputManager m_inputManager;

        // METHODS

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            m_inputManager = MAZ_InputManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            //Input based on our mouse movement.
            /*Make sure that we rotate independent of our current frame rate -> Time.deltaTime is the amount of time
            that has gone by since the last time the update function was called. If our frame rate is high we are not going to be rotating
            quicker than if our frame rate is low.*/

            float mouseX = (m_inputManager != null ? m_inputManager.GetMouseX() : Input.GetAxis("Mouse X")) * m_mouseSensitivity * Time.deltaTime;
            float mouseY = (m_inputManager != null ? m_inputManager.GetMouseY() : Input.GetAxis("Mouse Y")) * m_mouseSensitivity * Time.deltaTime;

            //Every frame we are going to decrease our xRotation based on mouseY.
            m_xRotation -= mouseY;

            // CLAMPING rotation: never over-rotate and look behind the player.
            m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

            /*Aply rotation. REMEMBER: Quaternions are responsible of rotation in Unity. Euler(xRotation, yRotation, zRotation).
             * This step is necessary for CLAMPING the rotation, that's why we do it this way instead of using playerBody.Rotate*/
            transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);

            //Specify an axis that we want to rotate around. Vector3.up -> y axis
            m_playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}

