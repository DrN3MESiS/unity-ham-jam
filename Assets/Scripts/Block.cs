using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public int id = 0;
    /* Properties */
    public Vector3 startPosition;

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
        this.startPosition = AppController.LastEnd;
        for (int i = 0; i < 10; i++)
        {
            Mountain mountainScript = new Mountain();

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
        mutation.MountainEntities = this.MountainEntities;
        for (int i = 0; i < this.MountainEntities.Count; i++)
        {
            mutation.MountainEntities[i] = this.MountainEntities[i].Mutate(noice);
        }        
        EvalBlock eval = new EvalBlock();
        eval.BlockGrade(mutation);
        // mutation.block.AddComponent<EvalBlock>().BlockGrade(mutation);
        return mutation;
    }

    public void Draw(){
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
                if (distance <= 1.0f)
                {
                    float height = curr.Exit.transform.position.y + (curr.exitHeight / 2.0f) - 0.25f;
                    if(next.Entry.transform.position.y < curr.Exit.transform.position.y){
                        height = next.Entry.transform.position.y + (next.entryHeight / 2.0f) - 0.25f;
                    }
                    Vector3 pos = new Vector3((curr.Exit.transform.position.x + (distance / 2.0f)), height, 0);
                    AppController.Draw(AppController.BridgePrefab, pos, AppController.BridgePrefab.transform.localScale, this.block.transform);
                    QuantityOfBridges++;
                }
            }
        }
    }
}
