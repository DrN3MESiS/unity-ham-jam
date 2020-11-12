using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public GameObject Entry_Prefab, Top_Prefab, Exit_Prefab, Tree_Prefab, Valley_Prefab, Ground_Prefab, Bridge_Prefab;
    public static GameObject EntryPrefab, TopPrefab, ExitPrefab, TreePrefab, ValleyPrefab, GroundPrefab, BridgePrefab;
    public static Vector3 LastEnd = Vector3.zero;
    public static float minHeight = -10;
    public static float spriteScale = 4.0f;
    Queue<Block> BlockScripts = new Queue<Block>();
    public static GameObject player;
    public Block curBlock;
    Mutate mutator = null;

    void Awake()
    {
        mutator = new Mutate();

        EntryPrefab = Entry_Prefab;
        TopPrefab = Top_Prefab;
        ExitPrefab = Exit_Prefab;
        TreePrefab = Tree_Prefab;
        ValleyPrefab = Valley_Prefab;
        GroundPrefab = Ground_Prefab;
        BridgePrefab = Bridge_Prefab;

        gameObject.tag = "Controller";
        gameObject.AddComponent<Mutate>();
        player = GameObject.FindGameObjectWithTag("Player");
        Block respawn = new Block();
        respawn.block = GameObject.FindGameObjectWithTag("Respawn");
        BlockScripts.Enqueue(respawn);
    }

    private void Start()
    {
        GenerateBlock();
    }

    private void Update() {
        if(curBlock != null){
            if(curBlock.HasPlayerPassed(player.transform.position)){
                Destroy(BlockScripts.Dequeue().block);
                GenerateBlock();
            }
        }
    }

    public void GenerateBlock(){
        curBlock = Mutate.BlockQueue.Dequeue();
        BlockScripts.Enqueue(curBlock);
        curBlock.Draw();        
        // Debug.Log("[GAME] >>>>>>> P1 Rendered and Obtained Block with Grade: " + curBlock.grade);
        curBlock.block.AddComponent<EvalBlock>().BlockGrade(curBlock);
        // Debug.Log("[GAME] >>>>>>> P2 Rendered and Obtained Block with Grade: " + curBlock.grade);
    }

    public static GameObject Draw(GameObject prefab, Vector3 pos, Vector3 scale, Transform parent)
    {
        GameObject inst = Instantiate(prefab, pos, Quaternion.Euler(0, 0, 0));
        inst.transform.localScale = scale;
        inst.transform.SetParent(parent);

        return inst;
    }
}
