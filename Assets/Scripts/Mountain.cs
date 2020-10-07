using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Sprite;
using UnityEngine.UI;
public class Mountain : MonoBehaviour
{
    public int id = 0;
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

    public GameObject _Valley;

    /* Properties Setup */
    public Mountain()
    {
        actualHeight = IntUtil.Random(heightRange[0], heightRange[1]);
        actualWidth = IntUtil.Random(widthRange[0], widthRange[1]);
        actualProximity = IntUtil.Random(proximityRange[0], proximityRange[1]);

        topWidth = IntUtil.Random(1, actualWidth - 1);
        entryWidth = IntUtil.Random(1, actualWidth - topWidth);
        exitWidth = actualWidth - topWidth - entryWidth;

        if (topWidth > Valley.width[0])
        {
            topIsValley = true;
        }
        else
        {
            topIsValley = false;
        }
    }

    void Start()
    {
        if (topIsValley)
        {
            if (this.Top != null)
            {
                _Valley = ObjectGenerator.GenerateValley(this.Top, id, 0, new Vector3(0, 0, 0), topWidth);
            }
        }
    }

}