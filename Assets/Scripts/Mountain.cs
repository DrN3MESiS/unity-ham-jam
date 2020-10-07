using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Sprite;
using UnityEngine.UI;
public class Mountain : MonoBehaviour
{
    public int id = 0;
    public Vector3 startPosition;
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
        AppController test = GameObject.FindGameObjectWithTag("Controller").GetComponent<AppController>();
        transform.position = startPosition;
        if (topIsValley)
        {
            if (this.Top != null)
            {
                // _Valley = ObjectGenerator.GenerateValley(this.Top, id, 0, Top.transform.position, topWidth);
                _Valley = ObjectGenerator.GenerateValley(this.Top, id, 0, Top.transform.position, topWidth, test.ValleyPrefab);
            }
        }

        // Debug.Log("actualWidth: " + actualWidth);
        this.transform.position += new Vector3(0, 1, 0);
        this.transform.localScale = new Vector3(this.transform.localScale.x * actualWidth, this.transform.localScale.y, this.transform.localScale.z);


        // Debug.Log("entryWidth: " + entryWidth);
        this.Entry.transform.position += new Vector3(0, 1.5f, 0);
        this.Entry.transform.localScale = new Vector3(this.Entry.transform.localScale.x * entryWidth, this.Entry.transform.localScale.y, this.Entry.transform.localScale.z);

        // Debug.Log("topWidth: " + topWidth);
        this.Top.transform.position += new Vector3(0, 1.6f, 0);
        this.Top.transform.localScale = new Vector3(this.Top.transform.localScale.x * topWidth, this.Top.transform.localScale.y, this.Top.transform.localScale.z);
        if (Exit != null)
        {
            // Debug.Log("exitWidth: " + exitWidth);
            this.Exit.transform.position += new Vector3(0, 1.5f, 0);
            this.Exit.transform.localScale = new Vector3(this.Exit.transform.localScale.x * exitWidth, this.Exit.transform.localScale.y, this.Exit.transform.localScale.z);
        }

    }

}