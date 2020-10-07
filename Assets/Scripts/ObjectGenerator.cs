using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public static GameObject GenerateBlock(int id, Vector3 initPos)
    {
        GameObject blockGameObject = new GameObject("Block_" + id);
        Block _script = blockGameObject.AddComponent<Block>();
        _script.id = id;
        _script.startPosition = initPos;
        return blockGameObject;
    }
    public static GameObject GenerateMountain(GameObject parent, int parentID, int myID, Vector3 initPos)
    {
        GameObject mountainGameObject = new GameObject("Mountain_" + parentID + "_" + myID);
        mountainGameObject.transform.SetParent(parent.transform);
        Mountain _mountainScript = mountainGameObject.AddComponent<Mountain>();
        _mountainScript.id = myID;
        _mountainScript.startPosition = initPos;

        GameObject EntryGameObject = new GameObject("Entry_" + myID);
        EntryGameObject.transform.SetParent(mountainGameObject.transform);
        _mountainScript.Entry = EntryGameObject;
        initPos = new Vector3(initPos.x + _mountainScript.entryWidth, initPos.y, initPos.z);
        EntryGameObject.transform.position = initPos;

        GameObject TopGameObject = new GameObject("Top_" + myID);
        TopGameObject.transform.SetParent(mountainGameObject.transform);
        _mountainScript.Top = TopGameObject;
        initPos = new Vector3(initPos.x + _mountainScript.topWidth, initPos.y, initPos.z);
        TopGameObject.transform.position = initPos;

        if (_mountainScript.exitWidth != 0)
        {
            GameObject ExitGameObject = new GameObject("Exit_" + myID);
            ExitGameObject.transform.SetParent(mountainGameObject.transform);
            _mountainScript.Exit = ExitGameObject;
            initPos = new Vector3(initPos.x + _mountainScript.exitWidth, initPos.y, initPos.z);
            ExitGameObject.transform.position = initPos;
        }

        return mountainGameObject;
    }

    public static GameObject GenerateValley(GameObject parent, int parentID, int myID, Vector3 initPosition, int width)
    {
        GameObject valleyGameObject = new GameObject("Valley_" + parentID + "_" + myID);
        valleyGameObject.transform.SetParent(parent.transform);
        Valley _valleyScript = valleyGameObject.AddComponent<Valley>();
        _valleyScript.id = myID;
        _valleyScript.actualWidth = width;
        _valleyScript.initPos = initPosition;

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
