using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valley : MonoBehaviour
{
    public int id = 0;
    public List<GameObject> TreeGameObjects = new List<GameObject>();

    public static float[] width = new float[2] { 3, 5 };
    public float actualWidth = 0;

    // /* Properties Setup */
    public Valley()
    {

    }

    void Start()
    {
        if (actualWidth > 1)
        {
            int numberOfTrees = IntUtil.Random(1, (int)actualWidth);
            for (int i = 0; i < actualWidth; i++)
            {
                GameObject tempTree = ObjectGenerator.GenerateTree(this.gameObject, this.id, i, new Vector3(0, 0, 0));
                TreeGameObjects.Add(tempTree);
            }
        }
        else
        {
            Debug.LogError("[VALLEY] >> Width came as 0");
        }
    }
}
