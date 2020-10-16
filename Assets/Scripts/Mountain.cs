using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Sprite;
using UnityEngine.UI;
public class Mountain
{
    public int id = 0;
    public Vector3 startPosition;
    /* Range Properties */
    public static int[] heightRange = new int[2] { 1, 5 };
    public static int[] widthRange = new int[2] { 6, 10 };
    public static int[] proximityRange = new int[2] { 0, 5 };

    /* Mountain Properties */
    public int actualHeight;
    public int actualWidth;
    public int actualProximity;

    public int topWidth;
    public int entryWidth;
    public int entryHeight;
    public int exitWidth;
    public int exitHeight;

    public bool topIsValley;

    public GameObject Entry;
    public GameObject Top;
    public GameObject Exit;
    public Valley valley;

    public GameObject mountain;

    /* Properties Setup */
    public Mountain(GameObject block)
    {
        this.mountain = new GameObject("Mountain");
        this.mountain.transform.SetParent(block.transform);
        this.startPosition = AppController.LastEnd;

        actualHeight = IntUtil.Random(heightRange[0], heightRange[1]);
        actualWidth = IntUtil.Random(widthRange[0], widthRange[1]);
        actualProximity = IntUtil.Random(proximityRange[0], proximityRange[1]);


        topWidth = IntUtil.Random(1, actualWidth - 1);
        entryWidth = IntUtil.Random(1, actualWidth - topWidth);
        exitWidth = actualWidth - topWidth - entryWidth;

        entryHeight = IntUtil.Random(heightRange[0], actualHeight);
        exitHeight = IntUtil.Random(heightRange[0],actualHeight);

        if (topWidth > Valley.width[0])
        {
            topIsValley = true;
        }
        else
        {
            topIsValley = false;
        }
    }

    public void Draw(){
        Vector3 lastPos = AppController.LastEnd;
        Vector3 pos = new Vector3(lastPos.x+(float)(entryWidth)/2.0f,lastPos.y+(float)(entryHeight)/2.0f,0);
        Vector3 scale = new Vector3((float)entryWidth/AppController.spriteScale,(float)entryHeight/AppController.spriteScale,1/AppController.spriteScale);
        
        Entry = AppController.Draw(AppController.EntryPrefab, pos, scale, this.mountain.transform);
        lastPos.x += this.entryWidth;
        lastPos.y += this.entryHeight;

        Ground(Entry.transform, (float)(entryWidth)/2.0f, 0);
        AppController.LastEnd = lastPos;   

        pos = new Vector3(lastPos.x+(float)(topWidth)/2.0f,lastPos.y-(float)(entryHeight)/2.0f,0);
        scale = new Vector3((float)topWidth/AppController.spriteScale,(float)entryHeight/AppController.spriteScale,1/AppController.spriteScale);
        
        GameObject topPrefab = AppController.TopPrefab;
        if(topIsValley){
            topPrefab = AppController.ValleyPrefab;
        }        
        Top = AppController.Draw(topPrefab, pos, scale, this.mountain.transform);
        lastPos.x += this.topWidth;        
        
        Ground(Top.transform, (float)(topWidth)/2.0f, (float)(entryHeight));
        AppController.LastEnd = lastPos;

        if(topIsValley){
            valley = new Valley(topWidth, Top.transform);
        }        

        pos = new Vector3(lastPos.x+(float)(exitWidth)/2.0f,lastPos.y-(float)(exitHeight)/2.0f,0);
        scale = new Vector3((float)exitWidth/AppController.spriteScale,(float)exitHeight/AppController.spriteScale,1/AppController.spriteScale);
        Exit = AppController.Draw(AppController.ExitPrefab, pos, scale, this.mountain.transform);
        lastPos.x += this.exitWidth;
        lastPos.y -= this.exitHeight;

        Ground(Exit.transform, (float)(exitWidth)/2.0f, (float)(exitHeight));
        AppController.LastEnd = lastPos;
    }
    
    public static void Ground(Transform parent, float x, float y){
        Vector3 scale = parent.localScale;
        Vector3 place = AppController.LastEnd;
        place.x += x;
        place.y -= y;
        float groundHeight = place.y - AppController.minHeight;
        place.y -= groundHeight / 2f;
        scale.y = groundHeight / AppController.spriteScale;
        AppController.Draw(AppController.GroundPrefab, place, scale, parent);
    }
}