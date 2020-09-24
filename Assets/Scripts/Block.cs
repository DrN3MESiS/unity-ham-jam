using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int unitWidth = 100;
    public int[] valleysEntityAmount = new int[2] { 0, 6 };
    public int[] mountainEntityAmount = new int[2] { 0, 8 };
    public int[] fuelEntityAmount = new int[2] { 2, 3 };
    // Start is called before the first frame update

    public List<Object> Entities = new List<Object>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
