using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valley : MonoBehaviour
{
    public List<Tree> TreeEntities = new List<Tree>();

    public static float[] width = new float[2] { 3, 5 };
    public float actualWidth = 0;
    public Valley(float width)
    {
        this.actualWidth = width;

        for (int i = 0; i < width; i++)
        {

            Tree testTree = Instantiate(new Tree((float)DoubleUtil.Random(Tree.scaleY[0], Tree.scaleY[1])));
            TreeEntities.Add(testTree);
        }
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
