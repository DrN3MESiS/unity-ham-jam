using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class User : MonoBehaviour
{
    public float maxSpeedMagnitude = 10f;
    public KeyCode MoveBackwards;
    public KeyCode MoveForward;
    public KeyCode Jump;
    private Rigidbody2D rb;
    public float realSpeed = -100.0f;
    public float jumpForce = 300f;
    public bool isGrounded = false;
    public float curVelocity = 0f;
    public bool idle = true;
    public int maxMeters = 0;
    public GameObject gasoline;
    public Vector2 limit;
    private Vector2 valuesOfFuel = new Vector2(60, 80);
    private float startingX;
    private float previousX;
    public float FuelQuantity = 100.0f;
    public int fuelsOn = 0;
    private Slider energySlider;
    public Text score;


    // Start is called before the first frame update
    void Start()
    {
        energySlider = GameObject.FindObjectOfType<Slider>();
        energySlider.value = FuelQuantity / 100.0f;
        rb = GetComponent<Rigidbody2D>();

        startingX = gameObject.transform.position.x;
        previousX = startingX;
        // MakeAppearGasoline();
        limit.x /= 2;
        limit.y /= 2;
        StartCoroutine(CheckForGasoline());
    }

    private void Update()
    {
        if (isGrounded)
        {
            // JUMP
            if (Input.GetKeyDown(Jump))
            {
                rb.AddForce(Vector2.up * jumpForce);
                // Debug.Log("Pressed SPACE");
            }
        }
        energySlider.value = FuelQuantity / 100.0f;
        score.text = maxMeters.ToString();
        IncreaseMeters();
        if (FuelQuantity > 100)
        {
            FuelQuantity = 100;
        }
    }

    private IEnumerator CheckForGasoline()
    {
        while (true)
        {
            if (FuelQuantity < 40)
            {
                if (fuelsOn < 2)
                {
                    MakeAppearGasoline();
                }
            }

            yield return new WaitForSeconds(10f);

        }
    }

    void FixedUpdate()
    {
        curVelocity = rb.velocity.x;

        // MOVE FORWARD
        if (Input.GetKey(MoveForward))
        {
            if (curVelocity <= maxSpeedMagnitude)
            {
                // Debug.Log("Forward");
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
            if (curVelocity >= -maxSpeedMagnitude)
            {
                // Debug.Log("Moving Backwards");
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

        if (FuelQuantity <= 0)
        {
            rb.velocity = Vector2.zero;
            ButtonsFunctions.Death();
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

    private void MakeAppearGasoline()
    {
        Vector3 pos;
        if (previousX < gameObject.transform.position.x)
        {
            pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            pos = new Vector3(previousX, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        pos.x += Random.Range(limit.x, limit.y);
        float quantityOfFuel = Random.Range(0.0f, 1.0f);
        if (quantityOfFuel > 0.5f)
        {
            quantityOfFuel = valuesOfFuel.y;
        }
        else
        {
            quantityOfFuel = valuesOfFuel.x;
        }
        pos.y += 2.0f;
        pos.x += 5.0f;

        previousX = pos.x;
        GameObject fuel_ = Instantiate(gasoline, pos, Quaternion.Euler(0, 0, 0));
        fuel_.GetComponent<Gasoline>().gasolineValue = (int)quantityOfFuel;
        fuelsOn++;
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

    private void IncreaseMeters()
    {
        maxMeters = (int)Mathf.Max(transform.position.x, (float)maxMeters);
        FuelQuantity -= Time.deltaTime * 2;
    }
}
