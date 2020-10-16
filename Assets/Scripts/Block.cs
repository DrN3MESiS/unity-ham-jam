using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public int id = 0;
    /* Properties */
    public Vector3 startPosition;
    private int maxWidth = 100;
    private static int[] fuelEntityAmount = new int[2] { 2, 3 };

    /*  */
    public List<Mountain> MountainEntities = new List<Mountain>();
    public int unitsLeft = 100;
    public GameObject block;

    /* UNITY METHODS */
    public Block()
    {
        this.block = new GameObject("Block");
        this.startPosition = AppController.LastEnd;

        // int i = 0;
        // while (true)
        // {

        // }
        for (int i = 0; i < 10; i++)
        {
           Mountain mountainScript = new Mountain(this.block);

            if (unitsLeft - mountainScript.actualWidth < 0)
            {
                break;
            }

            unitsLeft -= mountainScript.actualWidth;
            MountainEntities.Add(mountainScript);
            // i++;
        }
    }

    public void Draw(){
        foreach (Mountain mountain in this.MountainEntities)
        {
            mountain.Draw();
            // Debug.Log(mountain.valley);
            // if(mountain.valley != null){
            //     Debug.Log(mountain.valley.Trees.Count);
            // }
        }
    }
}
