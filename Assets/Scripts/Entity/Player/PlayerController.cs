using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 7f;
    public float sprintSpeed = 15f;
    public float crouchSpeed = 4f;

    public float walkTurnSpeed = 10f;
    public float sprintTurnSpeed = 0.001f;
    public float crouchTurnSpeed = 20f;
    public float turnSpeed;

    public float jumpVelocity = 7f;

    public bool isCrouched = false;
    public bool isRunning = false;
    public bool isWalking = true;
   

    public LayerMask groundLayers;
    public CapsuleCollider col;

    private Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();        
    }

    void Update()
    {
        MovementStates();
        Movement();        
    }


    //****************MOVEMENT*******************
    /*       1. Movement Overview
             2. Walk
             3. Sprint
             4. Sneak
             5. Jump
             6. Mouse Turn
      ******************************************/

    public void Movement()
    {
        MouseTurn();
        Jump();
        if (isWalking)
        {
            Walk();
        }
        else if (isCrouched)
        {
            Sneak();
        }
        else if (isRunning)
        {
            Sprint();
        }        
    }

    ////////////WALK/////////////////
    /// <summary>
    /// Main Movement
    /// </summary>
    public void Walk()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var y = moveSpeed * Time.deltaTime * -2.0f;
            transform.Translate(y, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            var y = moveSpeed * Time.deltaTime * 2.0f;
            transform.Translate(y, 0, 0);
        }
        var z = moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(0, 0, z);
       
    }

    /// <summary>
    /// Movement Sprint Speed
    /// </summary>
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var y = sprintSpeed * Time.deltaTime * -2.0f;
            transform.Translate(y, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            var y = sprintSpeed * Time.deltaTime * 2.0f;
            transform.Translate(y, 0, 0);
        }
        var z = sprintSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(0, 0, z);
    }

    ////////////SNEAK/////////////////
    /// <summary>
    /// Movement Sneak Speed
    /// </summary>
    public void Sneak()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var y = crouchSpeed * Time.deltaTime * -2.0f;
            transform.Translate(y, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            var y = crouchSpeed * Time.deltaTime * 2.0f;
            transform.Translate(y, 0, 0);
        }
        var z = crouchSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Translate(0, 0, z);
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
            rig.velocity = Vector3.up * jumpVelocity;
        }
    }

    ///////////MOUSE TURN///////////////
    /// <summary>
    /// Turns player left and right with mouse
    /// </summary>
    public void MouseTurn()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        float rotY = Input.GetAxis("Mouse X");

        gameObject.transform.Rotate(0, rotY * turnSpeed, 0);
        Vector3 speed = new Vector3(forward, 0.0f, side);
        rig.AddForce(speed);
    }

    //****************MOVEMENT DETAILS*******************
    /*          1. Movement States
                2. Is Grounded
    ************************************************/
    
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
                isCrouched = false;
                isWalking = true;
            }
            else
            {
                isWalking = false;
                isCrouched = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = false;
            isRunning = true;
            if (isCrouched)
            {
                isCrouched = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            isWalking = true;
        }

        if (isCrouched)
        {
            turnSpeed = crouchTurnSpeed;
        }
        else if (isRunning)
        {
            turnSpeed = sprintTurnSpeed;
        }
        else if (isWalking)
        {
            turnSpeed = walkTurnSpeed;
        }
    }     

    /// <summary>
    /// Checks to make sure player rigidbody is touching ground before being allowed to jump again
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
            col.bounds.center.z), col.radius * .9f, groundLayers);
    }    
}
