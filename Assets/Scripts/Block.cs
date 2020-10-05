using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : ScriptableObject
{
    /* Properties */
    private int maxWidth = 100;

    private int[] valleysEntityAmount = new int[2] { 0, 6 };
    private int[] mountainEntityAmount = new int[2] { 0, 8 };
    private int[] fuelEntityAmount = new int[2] { 2, 3 };

    /*  */
    public List<Mountain> Entities = new List<Mountain>();
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
            Mountain testMountain = ScriptableObject.CreateInstance<Mountain>();
            if (unitsLeft - testMountain.actualWidth < 0)
            {
                break;
            }

            if (testMountain.topIsValley)
            {
                CountOfValleys++;
            }

            Entities.Add(testMountain);
            unitsLeft -= testMountain.actualWidth;
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
