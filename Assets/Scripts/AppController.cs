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
    List<Block> BlockScripts = new List<Block>();


    Mutate mutator = null;
    IEnumerator GenerateGame()
    {
        // int i = 0;
        // while (true)
        // {

        // }
        for (int i = 0; i < 5; i++)
        {
            Block blockScript = new Block();
            blockScript.Draw();
            BlockScripts.Add(blockScript);
            yield return new WaitForSeconds(2);
            startReference = new Vector3(startReference.x + Mathf.Abs(blockScript.unitsLeft - 100), startReference.y, startReference.z);
            // i++;
            blockScript.block.AddComponent<EvalBlock>().BlockGrade(blockScript);
        }
    }
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
    }

    private void Start()
    {
        StartCoroutine(GenerateGame());
    }

    public static GameObject Draw(GameObject prefab, Vector3 pos, Vector3 scale, Transform parent)
    {
        GameObject inst = Instantiate(prefab, pos, Quaternion.Euler(0, 0, 0));
        inst.transform.localScale = scale;
        inst.transform.SetParent(parent);

        return inst;
    }
}
