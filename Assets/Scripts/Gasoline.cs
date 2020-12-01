using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasoline : MonoBehaviour
{
    // Start is called before the first frame update
    public int gasolineValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
            Debug.Log("Hit");
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            // Make Trigger
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            Vector3 pos = gameObject.transform.position;
            pos.y += 0.5f;
            gameObject.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            other.gameObject.GetComponent<User>().FuelQuantity+=gasolineValue;
            other.gameObject.GetComponent<User>().fuelsOn--;
            Destroy(gameObject);
        }
    }
}
