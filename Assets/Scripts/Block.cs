using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int id = 0;
    /* Properties */
    public Vector3 startPosition;
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
        transform.position = startPosition;
        AppController test = GameObject.FindGameObjectWithTag("Controller").GetComponent<AppController>();

        int i = 0;
        while (true)
        {

            // }
            // for (int i = 0; i < 4; i++)
            // {
            // GameObject tempMountain = ObjectGenerator.GenerateMountain(this.gameObject, id, i, startPosition);

            GameObject tempMountain = ObjectGenerator.GenerateMountain(this.gameObject, id, i, startPosition, test.MountainSetTestPrefab, test.MountainEntryPrefab, test.MountainTopPrefab, test.MountainExitPrefab);
            Mountain mountainScript = tempMountain.GetComponent<Mountain>();

            if (unitsLeft - mountainScript.actualWidth < 0)
            {
                Destroy(tempMountain);
                break;
            }

            unitsLeft -= mountainScript.actualWidth;
            MountainEntities.Add(tempMountain);

            startPosition = new Vector3(startPosition.x + mountainScript.actualWidth, startPosition.y, startPosition.z);
            i++;
        }


        // this.transform.localScale += new Vector3(Mathf.Abs(unitsLeft - 100), 0, 0);
        this.transform.localScale = new Vector3(this.transform.localScale.x * Mathf.Abs(unitsLeft - 100), transform.localScale.y, transform.localScale.z);
    }
}
