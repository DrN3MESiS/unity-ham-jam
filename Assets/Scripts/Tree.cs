using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Vector3 initPosition;
    public static float[] scaleY = new float[2] { 0.5f, 1.5f };
    public static int[] spawn = new int[2] { 1, 3 };
    public static float[] range = new float[2] { 1.5f, 3 };
    public static int BaseWidth = 1;

    public static float BaseHeight = 3;

    public float actualScale = 0;

    /* Properties Setup */
    public Tree()
    {
        actualScale = (float)DoubleUtil.Random(Tree.scaleY[0], Tree.scaleY[1]);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPosition;
        this.transform.position += new Vector3(0, 3, 0);
        // Debug.Log("\t\t\t\t\t[Tree.Start()] >>> Generated Tree!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
