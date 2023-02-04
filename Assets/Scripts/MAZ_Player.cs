using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class MAZ_Player : MonoBehaviour
    {
        // REFERENCES
       
        public CharacterController m_controller; //Reference to Player
        [SerializeField] private Transform m_groundCheck; //Reference to check if the empty object has reached the ground.
        [SerializeField] private Transform m_cameraTRS; //Reference to Main Camera
        private MAZ_ObjectGrabbable m_objectHit; //Reference to grabbed object.
        [SerializeField] private Image m_isCentered;
        private Color m_centeredRed = Color.red;
        private bool m_objGrabbed = false;


        // LAYERS

        /*We want to control what objects the sphere should check for.
        We don't want it to register as standing on the ground just bc it colLides with the player */
        [SerializeField] private LayerMask m_groundMask;
        [SerializeField] private LayerMask m_objectMask;

        //PHYSICS PARAMETERS

        [SerializeField] private float m_speed = 12f;
        [SerializeField] private float m_gravity = -9.81f;
        [SerializeField] private float m_groundDistance = 0.4f; //Radious of the sphere that we will be using to check.
        [SerializeField] private float m_detectionDistance = 15f; //Max distance that the Raycast achieve.
        private bool m_isGrounded; //Stores if it's grounded or not

        // MOVE SETTINGS

        private Vector3 m_velocity; // Is going to store our current velocity.

        

        // METHODS

        /// <summary>
        /// INTERACT()
        /// This method cast a ray from the position of the camera, in it's relative forward direction (not the "forward" of the full system),
        /// of lenght detectionDistance, against all colliders in the Scene. We provide an objectMask, to filter out anything we are not interested
        /// in generating a collision with.
        /// </summary>

         void Interact()
        {
            //Return true if it hits and false if it doesn't.
            RaycastHit hit;

            // Does the ray intersect any objects in the object Layer.
            if (Physics.Raycast(m_cameraTRS.position, m_cameraTRS.TransformDirection(Vector3.forward), out hit, m_detectionDistance, m_objectMask))
            {
                //Saves the object that produces the collision.
                Transform objectHit = hit.transform;
                m_isCentered.color = Color.red;
                //If the object that has been hit contains the script ObjectCollision, then return the object.
                if (objectHit.TryGetComponent<Test.MAZ_ObjectCollision>(out Test.MAZ_ObjectCollision _objI))
                {
                    Debug.Log(_objI.ID);
                }
                else if (objectHit.TryGetComponent<Test.MAZ_ObjectGrabbable>(out Test.MAZ_ObjectGrabbable _objG))
                {
                    Debug.Log(_objG.ID);
                    m_objectHit = _objG;
                }

            }
            else
            {
                m_isCentered.color = Color.white;
            }
        }

       


        // UPDATE is called once per frame

        void Update()
        {
            //If the sphere collides with anything that is in our groundMask, the isGrounded is going to be true.
            m_isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);

            if (m_isGrounded && m_velocity.y < 0)
            {
                //Works better than equal to 0.
                m_velocity.y = -2f;
            }

            //Get Input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            /*Direction we want to move. We don't want global coordinates.
             transform.right takes the direction that the player is facing and then goes right*/
            Vector3 move = transform.right * x + transform.forward * z;

            /*We want to control the movement but also the speed of the movement.
             Bc we are doing this inside the update method we need to multiply by Time.deltaTime to make it
            frame rate independent*/
            m_controller.Move(move * m_speed * Time.deltaTime);

            // Increment velocity in our up-down axis by some gravity number.
            m_velocity.y += m_gravity * Time.deltaTime;

            //Add this velocity to our player.
            m_controller.Move(m_velocity * Time.deltaTime);

            Interact();
            

            if (Input.GetMouseButtonDown(0) && !m_objGrabbed)
            {
                m_objectHit.Grab(m_objectHit.transform);
                m_objGrabbed = true;
            }
          
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                m_objectHit.transform.SetParent(null);
                m_objectHit = null;
                m_objGrabbed = false;
            }


        }
    }
}


