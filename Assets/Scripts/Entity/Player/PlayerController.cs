using UnityEngine;

namespace Assets.Scripts.Entity.Player
{
    public enum MovementState
    {
        Walking,
        Crouched,
        Running
    }

    public class PlayerController : MonoBehaviour
    {

        public float WalkSpeed { get; set; } = 7f;
        public float SprintSpeed { get; set; } = 12f;
        public float CrouchSpeed { get; set; } = 3f;

        public float WalkTurnSpeed { get; set; } = 10f;
        public float SprintTurnSpeed { get; set; } = 0.001f;
        public float CrouchTurnSpeed { get; set; } = 20f;
        public float TurnSpeed { get; set; } = 10f;

        public float JumpVelocity { get; set; } = 12f;

        public MovementState MovementState { get; set; } = MovementState.Walking;

        public LayerMask GroundLayers;
        public CapsuleCollider Col;

        private Rigidbody _rig;
        private float _movementSpeed;

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
            MouseTurn();
            Jump();
            Walk();
        }

        /// <summary>
        /// Main Movement
        /// movementSpeed set in MovementStates
        /// </summary>
        public void Walk()
        {
            var x = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                x = _movementSpeed * Time.deltaTime * -2.0f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                x = _movementSpeed * Time.deltaTime * 2.0f;
            }

            var z = _movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Translate(x, 0, z);
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
                _rig.velocity = Vector3.up * JumpVelocity;
            }
        }

        ///////////MOUSE TURN///////////////
        /// <summary>
        /// Turns player left and right with mouse
        /// </summary>
        public void MouseTurn()
        {
            var forward = Input.GetAxis("Vertical");
            var side = Input.GetAxis("Horizontal");
            var rotY = Input.GetAxis("Mouse X");

            gameObject.transform.Rotate(0, rotY * TurnSpeed, 0);
            var speed = new Vector3(forward, 0.0f, side);
            _rig.AddForce(speed);
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
            // If we aren't crouched then crouch, regardless of other states
            if (Input.GetKeyDown(KeyCode.LeftControl) && MovementState != MovementState.Crouched)
            {
                MovementState = MovementState.Crouched;
                _movementSpeed = CrouchSpeed;
                Debug.Log("movement state set to crouch");
            }
            // if we are crouched then uncrouch
            else if (Input.GetKeyDown(KeyCode.LeftControl) && MovementState == MovementState.Crouched)
            {
                MovementState = MovementState.Walking;
                _movementSpeed = WalkSpeed;
                Debug.Log("movement state set to walking");
            }
            // if we aren't already running, run
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                MovementState = MovementState.Running;
                _movementSpeed = SprintSpeed;
                Debug.Log("movement state set to running");
            }
            // if we have been running, stop running
            else if (MovementState == MovementState.Running)
            {
                MovementState = MovementState.Walking;
                _movementSpeed = WalkSpeed;
                Debug.Log("movement state set to walking");
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
