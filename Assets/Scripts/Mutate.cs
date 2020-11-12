using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutate : MonoBehaviour
{
    public static Queue<Block> BlockQueue = new Queue<Block>();
    public MutateListState currentState;
    private List<Block> TemporalBlockQueue = new List<Block>();
    public enum MutateListState
    {
        FULL,
        GENERATE,
        EMPTY
    }
    public float noice = 0.5f;

    IEnumerator WatchState()
    {
        while (true)
        {
            //Checks public block list length
            if (Mutate.BlockQueue.Count < 3)
            {
                currentState = MutateListState.GENERATE;
                Debug.Log("[MUTATOR] Changed state to: GENERATE");
            }
            else if (Mutate.BlockQueue.Count == 3)
            {
                if (currentState != MutateListState.FULL)
                {
                    Debug.Log("[MUTATOR] Changed state to: FULL");
                }
                currentState = MutateListState.FULL;
            }

            //Based on State, an action is determined

            if (currentState == MutateListState.GENERATE)
            {
                Debug.Log("[MUTATOR] Started Action: Re-Populate Queue");
                for (int i = 0; i < 3 - Mutate.BlockQueue.Count; i++)
                {
                    GenerateMutateAndRelease();
                }
                Debug.Log("[MUTATOR] Completed Action: Re-Populate Queue");
            }

            yield return new WaitForSeconds(1f);
        }
    }
    private void Awake()
    {
        Debug.Log("[MUTATOR] Started Action: Populate Initial Queue");
        GenerateMutateAndRelease();
        GenerateMutateAndRelease();
        GenerateMutateAndRelease();
        Debug.Log("[MUTATOR] Completed Action: Populate Initial Queue");
    }

    private void Start()
    {
        Debug.Log("[MUTATOR] Started Action: Start Watch Function");
        StartCoroutine(WatchState());
        Debug.Log("[MUTATOR] Completed Action: Start Watch Function");
    }

    private void GenerateMutateAndRelease()
    {
        Block bestBlock = null;

        //Create Blocks
        for (int i = 0; i < 12; i++)
        {
            EvalBlock eval = new EvalBlock();
            Block tmp = new Block();
            eval.BlockGrade(tmp);
            TemporalBlockQueue.Add(tmp);
        }

        // Debug.Log("Initial > : " + _PrintQueue());
        for (int i = 0; i < 5; i++)
        {
            _ReduceAndMutate();
            // Debug.Log("Mutation #" + (i + 1) + ": " + _PrintQueue());
        }

        bestBlock = TemporalBlockQueue[TemporalBlockQueue.Count - 1];
        Debug.Log("[MUTATOR] ===================== ADDED TO QUEUE BLOCK G: " + bestBlock.grade);
        Mutate.BlockQueue.Enqueue(bestBlock);
    }

    private string _PrintQueue()
    {
        Util.QuickSort(TemporalBlockQueue, 0, TemporalBlockQueue.Count - 1);
        string test = "";
        for (int i = 0; i < TemporalBlockQueue.Count; i++)
        {
            test += " [ (" + i + ") Grade: " + TemporalBlockQueue[i].grade + " ]";
        }

        return test;
    }



    private void _ReduceAndMutate()
    {
        int n = TemporalBlockQueue.Count;
        Util.QuickSort(TemporalBlockQueue, 0, n - 1);

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


        List<Block> toBeAdded = new List<Block>();
        for (int i = 0; i < TemporalBlockQueue.Count; i++)
        {
            Block test = TemporalBlockQueue[i];
            // Debug.Log("[" + i + "] BEFORE MUT: " + test.grade);
            Block mutated = test.Mutate(noice);
            // Debug.Log("[" + i + "] AFTER MUT: " + mutated.grade);

            toBeAdded.Add(mutated);
        }

        foreach (Block each in toBeAdded)
        {
            TemporalBlockQueue.Add(each);
        }

        Util.QuickSort(TemporalBlockQueue, 0, n - 1);


    }

}