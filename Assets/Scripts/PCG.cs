using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCG: MonoBehaviour
{
    List<Block> BlockScripts = new List<Block>();
    public float noice = 0.5f;
    public int noMutations = 5;
    
    void Start(){
        // for (int i = 0; i < 12; i++)
        // {
        //     Block blockScript = new Block();
        //     BlockScripts.Add(blockScript);
        //     EvalBlock eval = new EvalBlock();
        //     eval.BlockGrade(blockScript);
        // }

        // for (int noMutation = 0; noMutation < noMutations; noMutation++)
        // {
        //     BlockScripts.Sort((x,y) => y.grade.CompareTo(x.grade));
        //     for (int i = 0; i < 4; i++)
        //     {
        //         BlockScripts[BlockScripts.Count - 1 - i] =  BlockScripts[i].Mutate(noice);
        //     }          
        // }
        // BlockScripts.Sort((x,y) => y.grade.CompareTo(x.grade));

        // for (int i = 0; i < 5; i++)
        // {
        //     BlockScripts[i].Draw();
        //     BlockScripts[i].block.AddComponent<EvalBlock>().BlockGrade(BlockScripts[i]);
        // }
    }    
}
