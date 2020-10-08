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
        transform.position = initPos;
        AppController test = GameObject.FindGameObjectWithTag("Controller").GetComponent<AppController>();
        if (actualWidth > 1)
        {
            int numberOfTrees = IntUtil.Random(1, (int)Mathf.Floor(actualWidth));
            for (int i = 0; i < numberOfTrees; i++)
            {
                // GameObject tempTree = ObjectGenerator.GenerateTree(this.gameObject, this.id, i, initPos);
                GameObject tempTree = ObjectGenerator.GenerateTree(this.gameObject, this.id, i, initPos, test.TreePrefab);
                TreeGameObjects.Add(tempTree);
                initPos = new Vector3(initPos.x + Tree.BaseWidth, initPos.y, initPos.z);
            }

            this.transform.position += new Vector3(0, 2, 0);
            this.transform.localScale = new Vector3(this.transform.localScale.x * actualWidth, this.transform.localScale.y, this.transform.localScale.z);

        }
        else
        {
            Debug.LogError("[VALLEY] >> Width came as 0");
        }

    }
}
