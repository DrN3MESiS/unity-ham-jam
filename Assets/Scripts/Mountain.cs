using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour
{
    public float[] heightRange = new float[2] { 1, 8 };
    public float[] widthRange = new float[2] { 2, 6 };
    public float[] proximityRange = new float[2] { 0, 5 };
    private float density = 1;
    private float height;
    private float width;
    private float proximity;

    public List<Tree> TreeEntities;

    public Mountain(float height, float width, float proximity)
    {
        this.height = height;
        this.width = width;
        this.proximity = proximity;
        this.TreeEntities = trees;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
