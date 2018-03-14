using UnityEngine;

namespace Assets.Scripts.Entity.Player
{
   
    public class PlayerMovement : MonoBehaviour
    {

        public float        walkSpeed       = 7f;
        public float        sprintSpeed     = 12f;
        public float        crouchSpeed     = 3f;

        public float        walkTurnSpeed   = 10f;
        public float        sprintTurnSpeed = 0.001f;
        public float        crouchTurnSpeed = 20f;
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
        private float       _rotationVariationX=0f;
        private Quaternion     _followCamRotate;
        private Vector3     _followCamPosition;
        private float       _rotationSpeed  =10f;

        public void Start()
        {
            _rig = GetComponent<Rigidbody>();
            Col = GetComponent<CapsuleCollider>();
        }

        public void Update()
        {
            MovementStates();
            Movement();

            _rotationVariationX = followCam.transform.rotation.x - transform.rotation.x;
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
            _followCamRotate = followCam.rotation;
            float strafe = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
            float translation = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;

            Vector3 movement = new Vector3(strafe, 0f, translation);

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement)*_followCamRotate, _rotationSpeed*Time.deltaTime);                
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(0, 0, -1*strafe);
                }
                else
                {
                    transform.Translate(0, 0, strafe);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(0, 0, -1*translation);
                }
                else
                {
                    transform.Translate(0, 0,translation);
                    //transform.position = transform.position + followCam.transform.forward * translation * Time.deltaTime;
                }
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
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (isCrouched)
                {
                    isCrouched=false;
                }
                else
                {
                    isCrouched = true;
                }
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isCrouched = false;
                isRunning = true;
            }
            else
            {
                isCrouched = false;
                isRunning = false;
                isWalking = true;
            }

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
