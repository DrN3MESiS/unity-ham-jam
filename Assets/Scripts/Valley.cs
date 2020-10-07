using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valley : MonoBehaviour
{
    public int id = 0;
    public Vector3 initPos;
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
            int numberOfTrees = IntUtil.Random(1, (int)Mathf.Floor(actualWidth));
            for (int i = 0; i < numberOfTrees; i++)
            {
                GameObject tempTree = ObjectGenerator.GenerateTree(this.gameObject, this.id, i, initPos);
                TreeGameObjects.Add(tempTree);
                initPos = new Vector3(initPos.x + Tree.BaseWidth, initPos.y, initPos.z);
            }
        }
        else
        {
            Debug.LogError("[VALLEY] >> Width came as 0");
        }
    }
}
