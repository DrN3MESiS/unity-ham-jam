using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public int id = 0;
    /* Properties */
    public Vector3 startPosition, endPosition, center;

    public int QuantityOfBridges = 0;
    private static int[] fuelEntityAmount = new int[2] { 2, 3 };

    /*  */
    public List<Mountain> MountainEntities = new List<Mountain>();
    public int unitsLeft = 100;
    public GameObject block;

    public float grade;

    /* UNITY METHODS */
    public Block()
    {
        for (int i = 0; i < 10; i++)
        {
            Mountain mountainScript = new Mountain();
            mountainScript.SetMountainProperties();

            if (unitsLeft - mountainScript.actualWidth < 0)
            {
                break;
            }

            unitsLeft -= mountainScript.actualWidth;
            MountainEntities.Add(mountainScript);
        }
    }

    public Block Mutate(float noice){
        Block mutation = new Block();
        mutation.MountainEntities = new List<Mountain>();
        foreach (Mountain mountain in this.MountainEntities)
        {
            mutation.MountainEntities.Add(mountain.Mutate(noice));            
        }    
        EvalBlock eval = new EvalBlock();
        eval.BlockGrade(mutation);
        return mutation;
    }

    public bool HasPlayerPassed(Vector3 player){
        return player.x - this.center.x > 0;
    }

    public void Draw(){
        this.startPosition = AppController.LastEnd;
        this.block = new GameObject("Block");
        foreach (Mountain mountain in this.MountainEntities)
        {
            mountain.Draw(this.block);
        }

        for (int i = 0; i < this.MountainEntities.Count - 1; i++)
        {
            Mountain curr = this.MountainEntities[i];
            Mountain next = this.MountainEntities[i + 1];
            if (curr.Exit != null && next.Entry != null)
            {
                float distance = next.Entry.transform.position.x - curr.Exit.transform.position.x;
                if (distance <= 1.0f * AppController.sceneScale)
                {
                    float prefabHeight = 1/AppController.spriteScale;
                    prefabHeight *= (AppController.sceneScale - 1);
                    float height = curr.Exit.transform.position.y + (curr.exitHeight / 2.0f) - prefabHeight;
                    if(next.Entry.transform.position.y < curr.Exit.transform.position.y){
                        height = next.Entry.transform.position.y + (next.entryHeight / 2.0f) - prefabHeight;
                    }
                    Vector3 pos = new Vector3((curr.Exit.transform.position.x + (distance / 2.0f)), height, 0);
                    pos /= AppController.sceneScale;
                    AppController.Draw(AppController.BridgePrefab, pos, AppController.BridgePrefab.transform.localScale, this.block.transform);
                    QuantityOfBridges++;
                }
            }
        }        
        this.endPosition = AppController.LastEnd;
        this.center = this.block.transform.position;
        this.center.x = this.startPosition.x + (this.endPosition.x - this.startPosition.x) / 2f;
        this.center *= AppController.sceneScale;
    }
}
