using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public float maxMeters = 0;
    public GameObject gasoline;
    public Vector2 limit;
    private Vector2 valuesOfFuel = new Vector2(60, 80);
    private float startingX;
    private float previousX;
    public float FuelQuantity = 100.0f;
    public int fuelsOn = 0;
    private Slider energySlider;
    
    // Start is called before the first frame update
    void Start()
    {
        energySlider = GameObject.FindObjectOfType<Slider>();
        energySlider.value = FuelQuantity / 100.0f;
        rb = GetComponent<Rigidbody2D>();
        
        startingX = gameObject.transform.position.x;
        previousX = startingX;
        MakeAppearGasoline();
        limit.x /= 2;
        limit.y /= 2;
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
        if(FuelQuantity <= 0) {
            //TODO UI Message
            Debug.Log("Ya perdiste");
        }
        IncreaseMeters();
        CheckForGasoline();
    }

    private void CheckForGasoline(){
        energySlider.value = FuelQuantity / 100.0f;
        if (FuelQuantity < 80){
            if (fuelsOn < 2){
                MakeAppearGasoline();
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

        if (Input.GetKey(MoveBackwards))
        {
            rb.AddTorque(-1 * realSpeed * Time.fixedDeltaTime);
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

    private void MakeAppearGasoline(){
        Vector3 pos;
        if (previousX < gameObject.transform.position.x){
            pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else{
            pos = new Vector3(previousX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        
        pos.x += Random.Range(limit.x, limit.y);
        float quantityOfFuel = Random.Range(0.0f, 1.0f);
        if (quantityOfFuel > 0.5f){
            quantityOfFuel = valuesOfFuel.y;
        }
        else{
            quantityOfFuel = valuesOfFuel.x;
        }
        pos.y += 5.0f;
        
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

    private void IncreaseMeters(){
        maxMeters = Mathf.Max(transform.position.x, maxMeters);
        FuelQuantity -= Time.deltaTime;
    }
}
