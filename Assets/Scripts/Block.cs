using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int id = 0;
    /* Properties */
    private int maxWidth = 100;
    private static int[] fuelEntityAmount = new int[2] { 2, 3 };

    /*  */
    public List<GameObject> MountainEntities = new List<GameObject>();
    public int unitsLeft = 100;

    /* Properties Setup */
    public Block()
    {

    }

    /* UNITY METHODS */
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject tempMountain = ObjectGenerator.GenerateMountain(this.gameObject, id, i, new Vector3(0, 0, 0));
            Mountain mountainScript = tempMountain.GetComponent<Mountain>();

            if (unitsLeft - mountainScript.actualWidth < 0)
            {
                Destroy(tempMountain);
                break;
            }

            unitsLeft -= mountainScript.actualWidth;
            MountainEntities.Add(tempMountain);
        }
    }
}
