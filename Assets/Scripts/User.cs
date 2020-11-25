using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public KeyCode MoveBackwards;
    public KeyCode MoveForward;
    public KeyCode Jump;
    private Rigidbody2D rb;
    public float realSpeed = -50.0f;
    public float jumpForce = 50f;
    public bool isGrounded = false;
    public float curVelocity = 0f;
    public bool idle = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGrounded)
        {
            // JUMP
            if (Input.GetKeyDown(Jump))
            {
                rb.AddForce(Vector2.up * jumpForce);
                Debug.Log("Pressed SPACE");
            }
        }
    }

    void FixedUpdate()
    {
        curVelocity = rb.velocity.x;

        // MOVE FORWARD
        if (Input.GetKey(MoveForward))
        {
            if (curVelocity <= 15)
            {
                Debug.Log("Forward");
                rb.AddTorque(realSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (idle)
            {
                if (curVelocity > 1 && curVelocity > 0)
                {
                    rb.AddTorque(-1 * realSpeed * Time.fixedDeltaTime);
                }
            }
        }

        // MOVE BACKWARDS
        if (Input.GetKey(MoveBackwards))
        {
            if (curVelocity >= -15)
            {
                Debug.Log("Moving Backwards");
                rb.AddTorque(-1 * realSpeed * Time.fixedDeltaTime);
            }

        }
        else
        {
            if (idle)
            {
                if (curVelocity < 1 && curVelocity < 0)
                {
                    rb.AddTorque(realSpeed * Time.fixedDeltaTime);
                }
            }
        }



        if (!Input.GetKey(MoveBackwards) && !Input.GetKey(MoveForward))
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.transform.tag)
        {
            case "Ground":
                isGrounded = true;
                break;
            default:
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        switch (other.transform.tag)
        {
            case "Ground":
                isGrounded = false;
                break;
            default:
                break;
        }
    }
}
