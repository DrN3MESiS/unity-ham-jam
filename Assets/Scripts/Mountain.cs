using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Sprite;
using UnityEngine.UI;
public class Mountain : MonoBehaviour
{
    /* Range Properties */
    public static int[] heightRange = new int[2] { 5, 8 };
    public static int[] widthRange = new int[2] { 6, 10 };
    public static int[] proximityRange = new int[2] { 0, 5 };

    /* Mountain Properties */
    public int actualHeight;
    public int actualWidth;
    public int actualProximity;

    public int topWidth;
    public int entryWidth;
    public int exitWidth;

    public bool topIsValley;

    public GameObject Entry;
    public GameObject Top;
    public GameObject Exit;

    public Valley _valley = null;
    public Mountain()
    {
        actualHeight = IntUtil.Random(heightRange[0], heightRange[1]);
        actualWidth = IntUtil.Random(widthRange[0], widthRange[1]);
        actualProximity = IntUtil.Random(proximityRange[0], proximityRange[1]);

        topWidth = IntUtil.Random(1, actualWidth - 1);
        entryWidth = IntUtil.Random(1, actualWidth - topWidth);
        exitWidth = actualWidth - topWidth - entryWidth;

    }

    void Start()
    {
        //Debug.Log("\t\t[Mountain.Start()] Created Mountain");

        // Debug.LogFormat("\t\t[Mountain] > Width: " + actualWidth + ", Height: " + actualHeight + ", TopW: " + topWidth + ", EntryW: " + entryWidth + ", ExitW: " + exitWidth + "");
        // Debug.LogFormat("\t\t[Mountain] > TopIsValley? " + (topWidth > Valley.width[0]) + "");

        if (entryWidth != 0)
            Entry = new GameObject("Entry_");

        Top = new GameObject("Top_");

        if (exitWidth != 0)
            Exit = new GameObject("Exit_");



        if (topWidth > Valley.width[0])
        {
            topIsValley = true;
            _valley = Top.AddComponent<Valley>();
            _valley.Generate(topWidth);
        }
        else
        {
            topIsValley = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }



}