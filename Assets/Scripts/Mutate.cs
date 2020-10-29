using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutate
{
    public static List<Block> BlockQueue = new List<Block>();
    public MutateListState currentState;
    private List<Block> TemporalBlockQueue = new List<Block>();
    public enum MutateListState
    {
        FULL,
        GENERATE,
        EMPTY
    }

    IEnumerator WatchState()
    {

        //Checks public block list length
        if (Mutate.BlockQueue.Count < 3)
        {
            currentState = MutateListState.GENERATE;
        }
        else if (Mutate.BlockQueue.Count == 3)
        {
            currentState = MutateListState.FULL;
        }

        //Based on State, an action is determined

        if (currentState == MutateListState.GENERATE)
        {
            for (int i = 0; i < 3 - Mutate.BlockQueue.Count; i++)
            {
                GenerateMutateAndRelease();
            }
        }

        yield return new WaitForSeconds(1);
    }

    public Mutate()
    {
        GenerateMutateAndRelease();
        Debug.Log("Static Block Queue: " + Mutate.BlockQueue);
        // GenerateMutateAndRelease();
        // GenerateMutateAndRelease();

        // StartCoroutine(WatchState());
    }

    private void GenerateMutateAndRelease()
    {
        Block bestBlock = null;

        //Create Blocks
        EvalBlock eval = new EvalBlock();
        for (int i = 0; i < 12; i++)
        {
            Block tmp = new Block();
            eval.BlockGrade(tmp);
            TemporalBlockQueue.Add(tmp);
        }

        //Sort
        while (TemporalBlockQueue.Count > 1)
        {
            Reduce();
        }

        Debug.Log("Count:" + TemporalBlockQueue.Count);

        Mutate.BlockQueue.Add(bestBlock);
    }



    private void Reduce()
    {
        int n = TemporalBlockQueue.Count;
        Util.QuickSort(TemporalBlockQueue, 0, n - 1);
        Util.printArray(TemporalBlockQueue);

        int newSize = (int)(TemporalBlockQueue.Count / 2);
        if (newSize <= 1)
        {
            return;
        }

        for (int i = 0; i < newSize; i++)
        {
            if (TemporalBlockQueue.Count > 1)
            {
                TemporalBlockQueue.RemoveAt(0);
            }
            else
            {
                break;
            }
        }
    }

}