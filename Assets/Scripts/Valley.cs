using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valley : MonoBehaviour
{
    public List<GameObject> TreeGameObjects = new List<GameObject>();
    public List<Tree> TreeEntities = new List<Tree>();

    public static float[] width = new float[2] { 3, 5 };
    public float actualWidth = 0;

    public void Generate(float width)
    {
        this.actualWidth = width;

        for (int i = 0; i < width; i++)
        {
            GameObject testTree = new GameObject("Tree_");
            Tree _scriptTree = testTree.AddComponent<Tree>();

            TreeEntities.Add(_scriptTree);
            TreeGameObjects.Add(testTree);
            Debug.Log("\t\t\t\t[Valley.Generate()] >> Created Tree");
        }
    }


    void Start()
    {
        Debug.Log("\t\t\t[Valley.Start] >> Created Valley");
    }

    void Update()
    {

    }
}
