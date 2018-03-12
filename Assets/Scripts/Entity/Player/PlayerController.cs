using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 7f;
    public float sprintSpeed = 15f;
    public float crouchSpeed = 4f;

    public float walkTurnSpeed = 10f;
    public float sprintTurnSpeed = 0.001f;
    public float crouchTurnSpeed = 20f;
    public float turnSpeed=10f;

    public float jumpVelocity = 7f;

    public bool isCrouched = false;
    public bool isRunning = false;
    public bool isWalking = true;
   

    public LayerMask groundLayers;
    public CapsuleCollider col;

    private Rigidbody rig;
    private float movementSpeed;

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
             5. Jump
             6. Mouse Turn
      ******************************************/

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
        float x=0f;
        float z=0f;
        
        if (Input.GetKey(KeyCode.A))
        {
            x = movementSpeed * Time.deltaTime * -2.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x = movementSpeed * Time.deltaTime * 2.0f;
        }
        z = movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

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
                isRunning = false;
                isWalking = false;
                isCrouched = true;
                movementSpeed = crouchSpeed;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = false;
            isCrouched = false;
            isRunning = true;
            movementSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            isWalking = true;
        }
        else if (isWalking)
        {
            isRunning = false;
            isCrouched = false;
            movementSpeed = walkSpeed;
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
