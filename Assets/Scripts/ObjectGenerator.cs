using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{

    // public static GameObject GenerateBlock(int id, Vector3 initPos)
    public static GameObject GenerateBlock(int id, Vector3 initPos, GameObject BlockPrefab)
    {
        // GameObject blockGameObject = new GameObject("Block_" + id);
        GameObject blockGameObject = Instantiate(BlockPrefab); //TEST
        blockGameObject.name = "Block_" + id; //TEST
        Block _script = blockGameObject.AddComponent<Block>();
        _script.id = id;
        _script.startPosition = initPos;
        return blockGameObject;
    }
    // public static GameObject GenerateMountain(GameObject parent, int parentID, int myID, Vector3 initPos)
    public static GameObject GenerateMountain(GameObject parent, int parentID, int myID, Vector3 initPos, GameObject MountainPrefab, GameObject EntryPrefab, GameObject TopPrefab, GameObject ExitPrefab)
    {
        // GameObject mountainGameObject = new GameObject();
        GameObject mountainGameObject = Instantiate(MountainPrefab);  //TEST
        mountainGameObject.name = "Mountain_" + parentID + "_" + myID;
        // mountainGameObject.transform.SetParent(parent.transform);
        Mountain _mountainScript = mountainGameObject.AddComponent<Mountain>();
        _mountainScript.id = myID;
        _mountainScript.startPosition = initPos;

        // GameObject EntryGameObject = new GameObject();
        GameObject EntryGameObject = Instantiate(EntryPrefab); //TEST
        EntryGameObject.name = "Entry_" + myID;
        // EntryGameObject.transform.SetParent(mountainGameObject.transform);
        _mountainScript.Entry = EntryGameObject;
        EntryGameObject.transform.position = initPos;
        initPos = new Vector3(initPos.x + _mountainScript.entryWidth, initPos.y, initPos.z);

        // GameObject TopGameObject = new GameObject("Top_" + myID);
        GameObject TopGameObject = Instantiate(TopPrefab); //TEST
        TopGameObject.name = "Top_" + myID;
        // TopGameObject.transform.SetParent(mountainGameObject.transform);
        _mountainScript.Top = TopGameObject;
        TopGameObject.transform.position = initPos;
        initPos = new Vector3(initPos.x + _mountainScript.topWidth, initPos.y, initPos.z);

        if (_mountainScript.exitWidth != 0)
        {
            // GameObject ExitGameObject = new GameObject();
            GameObject ExitGameObject = Instantiate(ExitPrefab); //TEST
            ExitGameObject.name = "Exit_" + myID;
            // ExitGameObject.transform.SetParent(mountainGameObject.transform);
            _mountainScript.Exit = ExitGameObject;
            ExitGameObject.transform.position = initPos;
            initPos = new Vector3(initPos.x + _mountainScript.exitWidth, initPos.y, initPos.z);
        }

        return mountainGameObject;
    }

    // public static GameObject GenerateValley(GameObject parent, int parentID, int myID, Vector3 initPosition, int width) 
    public static GameObject GenerateValley(GameObject parent, int parentID, int myID, Vector3 initPosition, int width, GameObject ValleyPrefab)//TEST
    {
        // GameObject valleyGameObject = new GameObject();
        GameObject valleyGameObject = Instantiate(ValleyPrefab); //TEST
        valleyGameObject.name = "Valley_" + parentID + "_" + myID;
        // valleyGameObject.transform.SetParent(parent.transform);
        Valley _valleyScript = valleyGameObject.AddComponent<Valley>();
        _valleyScript.id = myID;
        _valleyScript.actualWidth = width;
        _valleyScript.initPos = initPosition;

        return valleyGameObject;
    }

    // public static GameObject GenerateTree(GameObject parent, int parentID, int myID, Vector3 initPos)
    public static GameObject GenerateTree(GameObject parent, int parentID, int myID, Vector3 initPos, GameObject TreePrefab) //TEST
    {
        // GameObject treeGameObject = new GameObject();
        GameObject treeGameObject = Instantiate(TreePrefab); //TEST
        treeGameObject.name = "Tree_" + parentID + "_" + myID;
        // treeGameObject.transform.SetParent(parent.transform);
        Tree _treeScript = treeGameObject.AddComponent<Tree>();
        _treeScript.initPosition = initPos;

        return treeGameObject;
    }
}
