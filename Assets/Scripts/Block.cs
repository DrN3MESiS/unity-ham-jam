using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /* Properties */
    private int maxWidth = 100;

    private int[] valleysEntityAmount = new int[2] { 0, 6 };
    private int[] mountainEntityAmount = new int[2] { 0, 8 };
    private int[] fuelEntityAmount = new int[2] { 2, 3 };

    /*  */
    public List<GameObject> Entities = new List<GameObject>();
    public List<Mountain> Scripts = new List<Mountain>();
    public int CountOfValleys = 0;
    private int unitsLeft = 100;

    /* UNITY METHODS */
    void Start()
    {

    }
    void Update()
    {

    }

    /* CLASS METHODS */

    public int Generate()
    {
        /*First Pass*/
        while (true)
        {
            GameObject testMountain = new GameObject();
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

        Debug.Log("unitsLeft on Block after Generation: " + unitsLeft);
        Debug.Log("Mountains Generated: " + Entities.Count);
        Debug.Log("Valley: " + CountOfValleys);

        return 0;
    }

    /* Getters and Setters */
    public int GetMaxWidth()
    {
        return maxWidth;
    }
    public int GetMinValleyAmount()
    {
        return valleysEntityAmount[0];
    }
    public int GetMaxValleyAmount()
    {
        return valleysEntityAmount[1];
    }
    public int GetMinMountainAmount()
    {
        return mountainEntityAmount[0];
    }
    public int GetMaxMountainAmount()
    {
        return mountainEntityAmount[1];
    }
    public int GetMinFuelAmount()
    {
        return fuelEntityAmount[0];
    }
    public int GetMaxFuelAmount()
    {
        return fuelEntityAmount[1];
    }
}
