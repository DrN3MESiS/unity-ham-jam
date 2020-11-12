using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public KeyCode MoveForward;
    public KeyCode Jump;
    private Rigidbody2D rb;
    public float forwardSpeed = -50.0f;
    public float jumpForce = 20f;
    public bool isTouching = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(MoveForward))
        {
            rb.AddTorque(forwardSpeed * Time.fixedDeltaTime);
        }


        if (Input.GetKeyDown(Jump))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
