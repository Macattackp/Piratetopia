using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 7f;
    public float sprintSpeed = 15f;
    public float turnSpeed = 1.5f;
    public float sprintTurnSpeed = 0.001f;
    public float jumpVelocity = 7f;
   

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
        Movement();

        Jump();
    }


    //****************MOVEMENT*******************

    public void Movement()
    {
        MouseTurn();
        Walk();
        Sprint();
    }

    /// <summary>
    /// Moves players in 4 directions with WASD setup
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
    /// Allows player to move faster with sprint. Sprint turning and speed are set to different floats for fine tuning
    /// </summary>
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float sprintX = sprintTurnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            float sprintZ = sprintSpeed * Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, sprintX, 0);
            transform.Translate(0, 0, sprintZ);
            if (Input.GetKey(KeyCode.A))
            {
                float y = sprintSpeed * Time.deltaTime * -2.0f;
                transform.Translate(y, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                float y = sprintSpeed * Time.deltaTime * 2.0f;
                transform.Translate(y, 0, 0);
            }
        }
    }


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

    /// <summary>
    /// Checks to make sure player rigidbody is touching ground before being allowed to jump again
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
            col.bounds.center.z), col.radius * .9f, groundLayers);
    }

    /// <summary>
    /// Allows player to jump with space. See "BetterJump for variables affecting jump path
    /// </summary>
    public void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity=Vector3.up * jumpVelocity;
        }
    }
}
