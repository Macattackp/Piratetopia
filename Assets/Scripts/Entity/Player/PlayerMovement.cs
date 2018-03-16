using UnityEngine;

namespace Assets.Scripts.Entity.Player
{
   
    public class PlayerMovement : MonoBehaviour
    {

        public float        walkSpeed       = 7f;
        public float        sprintSpeed     = 12f;
        public float        crouchSpeed     = 3f;
        
        public float        turnSpeed       = 10f;

        public float        jumpVelocity    = 12f;

        public bool         isWalking       = true;
        public bool         isRunning       = false;
        public bool         isCrouched      = false;

        public LayerMask    GroundLayers;
        public CapsuleCollider Col;
        public Transform   followCam;

        private Rigidbody   _rig;
        private float       _movementSpeed;
        private Quaternion     _followCamRotate;

        public void Start()
        {
            _rig = GetComponent<Rigidbody>();
            Col = GetComponent<CapsuleCollider>();
        }

        public void Update()
        {
            MovementStates();
            Movement();
        }

        /****************MOVEMENT*******************/
        /*     1. Movement Overview
        /*     2. Walk         
        /*     5. Jump
        /*     6. Mouse Turn
        /********************************************/
        public void Movement()
        {            
            Jump();
            Walk();
        }

        /// <summary>
        /// Main Movement
        /// movementSpeed set in MovementStates
        /// </summary>
        public void Walk()
        {
            _followCamRotate = Quaternion.Euler(0,followCam.rotation.y,0);

            Vector3 movement = Vector3.zero; 

            if (Input.GetKey(KeyCode.W))  {movement += followCam.forward;}
            if (Input.GetKey(KeyCode.S))  {movement += -followCam.forward;}
            if (Input.GetKey(KeyCode.A))  {movement += -followCam.right;}
            if (Input.GetKey(KeyCode.D))  {movement += followCam.right;}

            movement.y = 0;
            transform.position += movement.normalized * _movementSpeed * Time.deltaTime;

            if (movement != Vector3.zero)
            {
                transform.rotation = _followCamRotate* Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), turnSpeed * Time.deltaTime);
            }
        }
        
        /////////////JUMP////////////////////
        /// <summary>
        /// Jump Ability
        /// See "Better Jump" for jump parabola
        /// </summary>
        public void Jump()
        {
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                _rig.velocity = Vector3.up * jumpVelocity;
            }
        }
        

        /****************MOVEMENT DETAILS****************/
        /*          1. Movement States
        /*        2. Is Grounded
        /************************************************/

        ///////////MOVEMENT STATES///////////////////
        /// <summary>
        /// Controls which state of movement player is in. 
        /// Player can only be in one state at a time
        /// </summary>
        public void MovementStates()
        {   //Keybindings
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!isCrouched)
                {
                    isCrouched=true;
                }
                else
                {
                    isCrouched = false;
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isCrouched = false;
                isRunning = true;
            }
            else
            {
                isRunning = false;
                isWalking = true;
            }

            //Speed Assignments
            if (isCrouched)
            {
                _movementSpeed = crouchSpeed;
            }
            else if (isRunning)
            {
                _movementSpeed = sprintSpeed;
            }

            else if (isWalking)
            {
                _movementSpeed = walkSpeed;
            }

            else
            {
                Debug.Log("You Have No Movement State!");
            }           
        }

        /// <summary>
        /// Checks to make sure player rigidbody is touching ground before being allowed to jump again
        /// </summary>
        /// <returns></returns>
        private bool IsGrounded()
        {
            return Physics.CheckCapsule(
                Col.bounds.center,
                new Vector3(
                    Col.bounds.center.x,
                    Col.bounds.min.y,
                    Col.bounds.center.z),
                Col.radius * .9f,
                GroundLayers);
        }
    }
}
