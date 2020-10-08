using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
