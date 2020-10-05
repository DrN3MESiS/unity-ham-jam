using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Vector3 size;
    public static float[] scaleY = new float[2] { 0.5f, 1.5f };
    public static int[] spawn = new int[2] { 1, 3 };
    public static float[] range = new float[2] { 1.5f, 3 };

    public static float BaseHeight = 3;

    public float actualHeight = 0;

    public Tree(float height)
    {
        actualHeight = height;
    }

    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
