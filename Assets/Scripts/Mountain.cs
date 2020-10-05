using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountain : MonoBehaviour
{
    /* Range Properties */
    public int[] heightRange = new int[2] { 5, 8 };
    public int[] widthRange = new int[2] { 6, 10 };
    public int[] proximityRange = new int[2] { 0, 5 };

    /* Mountain Properties */
    public int actualHeight;
    public int actualWidth;
    public int actualProximity;

    public int topWidth;
    public int entryWidth;
    public int exitWidth;

    public bool topIsValley;

    /* Testing */
    public List<Valley> ValleyEntities = new List<Valley>();

    public Mountain()
    {
        actualHeight = IntUtil.Random(heightRange[0], heightRange[1]);
        actualWidth = IntUtil.Random(widthRange[0], widthRange[1]);
        actualProximity = IntUtil.Random(proximityRange[0], proximityRange[1]);

        topWidth = IntUtil.Random(1, actualWidth - 1);
        entryWidth = IntUtil.Random(0, actualWidth - topWidth);
        exitWidth = actualWidth - topWidth - entryWidth;

        if (topWidth > Valley.width[0])
        {
            topIsValley = true;
            Valley testValley = Instantiate(new Valley(topWidth));
            ValleyEntities.Add(testValley);
        }
        else
        {
            topIsValley = false;
        }

        Debug.Log("Mountain(Height: " + actualHeight + "; Width: " + actualWidth + "; Proximity: " + actualProximity + "; TopW: " + topWidth + "; EntryW: " + entryWidth + "; ExitW: " + exitWidth + ")");
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



}