using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    public Vector3 initPosition;
    public static float[] scaleY = new float[2] { 0.75f, 1.5f };
    public static int[] spawn = new int[2] { 0, 3 };
    public static float[] range = new float[2] { 0.5f, 2 };
    public float actualScale = 0;
    public GameObject tree;

    /* Properties Setup */
    public Tree()
    {
        actualScale = (float)DoubleUtil.Random(Tree.scaleY[0], Tree.scaleY[1]);
    }

    public void Draw(int x, Transform parent){
        Vector3 lastPos = AppController.LastEnd;
        lastPos.x += x;
        Vector3 scale = AppController.TreePrefab.transform.localScale;
        scale *= actualScale;
        lastPos.y += scale.y * 5.0f;
        this.tree = AppController.Draw(AppController.TreePrefab, lastPos, scale, parent);
        this.initPosition = lastPos;
    }
}
