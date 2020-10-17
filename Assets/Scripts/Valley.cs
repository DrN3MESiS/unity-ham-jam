using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valley
{
    public int id = 0;
    public List<Tree> Trees = new List<Tree>();

    public static float[] width = new float[2] { 3, 5 };

    // /* Properties Setup */
    public Valley(int width, Transform parent)
    {
        float halfNumberOfTrees = (float)IntUtil.Random(Tree.spawn[0], Tree.spawn[1] + 1) / 2.0f;
        int min = (int)Mathf.Floor(halfNumberOfTrees);
        int max = (int)Mathf.Ceil(halfNumberOfTrees);
        float distance = (float)DoubleUtil.Random(Tree.range[0], Tree.range[1]);
        for (int i = -min; i < max; i++)
        {
            Tree tempTree = new Tree();
            // tempTree.Draw(i - (width / 2), parent);
            tempTree.Draw((int)(((float)i * distance) - ((float)width / 2.0f)), parent);
            Trees.Add(tempTree);
        }
    }
}
