using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /* Properties */
    private int maxWidth = 100;

    private static int[] valleysEntityAmount = new int[2] { 0, 6 };
    private static int[] mountainEntityAmount = new int[2] { 0, 8 };
    private static int[] fuelEntityAmount = new int[2] { 2, 3 };

    /*  */
    public List<GameObject> Entities = new List<GameObject>();
    public List<Mountain> Scripts = new List<Mountain>();
    public int CountOfValleys = 0;
    private int unitsLeft = 100;

    /* UNITY METHODS */
    void Start()
    {

        //Debug.Log("[Block.Start()] >> " + "Generated Block");


        while (true)
        {
            GameObject testMountain = new GameObject("Mountain_");
            Mountain _mountainScript = testMountain.AddComponent<Mountain>();

            if (unitsLeft - _mountainScript.actualWidth < 0)
            {
                break;
            }


            if (_mountainScript.topIsValley)
            {
                CountOfValleys++;
            }

            Entities.Add(testMountain);
            Scripts.Add(_mountainScript);
            unitsLeft -= _mountainScript.actualWidth;

        }

        /*Debug.Log("Mountains Generated: " + Entities.Count);
        Debug.Log("Valley: " + CountOfValleys);*/
    }
    void Update()
    {

    }
}
