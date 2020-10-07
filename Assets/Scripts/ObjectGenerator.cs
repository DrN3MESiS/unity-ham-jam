using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public static GameObject GenerateBlock(int id, Vector3 initPös)
    {
        GameObject blockGameObject = new GameObject("Block_" + id);
        Block _script = blockGameObject.AddComponent<Block>();
        return blockGameObject;
    }
    public static GameObject GenerateMountain(GameObject parent, int parentID, int myID, Vector3 initPos)
    {
        GameObject mountainGameObject = new GameObject("Mountain_" + parentID + "_" + myID);
        mountainGameObject.transform.SetParent(parent.transform);
        Mountain _mountainScript = mountainGameObject.AddComponent<Mountain>();

        GameObject EntryGameObject = new GameObject("Entry_" + myID);
        EntryGameObject.transform.SetParent(mountainGameObject.transform);

        GameObject TopGameObject = new GameObject("Top_" + myID);
        TopGameObject.transform.SetParent(mountainGameObject.transform);

        if (_mountainScript.exitWidth != 0)
        {
            GameObject ExitGameObject = new GameObject("Exit_" + myID);
            TopGameObject.transform.SetParent(mountainGameObject.transform);
        }

        return mountainGameObject;
    }

    public static GameObject GenerateValley(GameObject parent, int parentID, int myID, Vector3 initPosition)
    {
        GameObject valleyGameObject = new GameObject("Valley_" + parentID + "_" + myID);
        valleyGameObject.transform.SetParent(parent.transform);
        Valley _valleyScript = valleyGameObject.AddComponent<Valley>();

        return valleyGameObject;
    }

    public static GameObject GenerateTree(GameObject parent, int parentID, int myID, Vector3 initPos)
    {
        GameObject treeGameObject = new GameObject("Tree_" + parentID + "_" + myID);
        treeGameObject.transform.SetParent(parent.transform);
        Tree _treeScript = treeGameObject.AddComponent<Tree>();

        return treeGameObject;
    }
}
