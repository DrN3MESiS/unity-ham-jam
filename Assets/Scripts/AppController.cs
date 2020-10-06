using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    List<GameObject> BlockController = new List<GameObject>();
    List<Block> BlockScripts = new List<Block>();

    void Start()
    {

        GameObject initBlock = new GameObject("Block_");
        Block _blockScript = initBlock.AddComponent<Block>();

        BlockController.Add(initBlock);
        BlockScripts.Add(_blockScript);
    }
}
