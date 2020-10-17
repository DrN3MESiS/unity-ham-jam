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

        for(int i = 0; i < this.MountainEntities.Count - 1; i++){
            Mountain curr = this.MountainEntities[i];
            Mountain next = this.MountainEntities[i+1];
            if(curr.Exit != null && next.Entry != null){
                float distance = next.Entry.transform.position.x - curr.Exit.transform.position.x;
                if(distance <= 1.0f){
                    float height = curr.Exit.transform.position.y + (curr.exitHeight / 2.0f) - 0.25f;
                    if(next.Entry.transform.position.y < height){
                        height = next.Entry.transform.position.y + (next.entryHeight / 2.0f) - 0.25f;
                    }
                    Vector3 pos = new Vector3((curr.Exit.transform.position.x + (distance/2.0f)),height,0);
                    AppController.Draw(AppController.BridgePrefab, pos, AppController.BridgePrefab.transform.localScale, this.block.transform);
                }
            }
        }
    }
}
