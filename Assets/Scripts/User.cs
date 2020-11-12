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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        curVelocity = rb.velocity.magnitude;
        if (Input.GetKey(MoveForward))
        {
            rb.AddTorque(realSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(MoveBackwards))
        {
            rb.AddTorque(-1 * realSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(Jump))
        {
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime);
            Debug.Log("Pressed SPACE");
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
