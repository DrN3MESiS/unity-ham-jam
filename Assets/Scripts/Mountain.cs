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

    /* Mountain Properties */
    public int actualHeight = 0;
    public int actualWidth = 0;

    public int topWidth = 0;
    public int entryWidth = 0;
    public int entryHeight = 0;
    public int topHeight = 1;
    public int exitWidth = 0;
    public int exitHeight = 0;

    public bool topIsValley = false;

    public GameObject Entry;
    public GameObject Top;
    public GameObject Exit;
    public Valley valley;

    public GameObject mountain;    
    /* Properties Setup */
    public void SetMountainProperties()
    {
        this.startPosition = AppController.LastEnd;

        this.actualHeight = IntUtil.Random(heightRange[0], heightRange[1]);
        this.actualWidth = IntUtil.Random(widthRange[0], widthRange[1]);

        this.topWidth = IntUtil.Random(1, this.actualWidth + 1);
        this.exitWidth = IntUtil.Random(0, this.actualWidth - this.topWidth + 1);
        this.entryWidth = this.actualWidth - this.topWidth - this.exitWidth;

        if(this.entryWidth != 0){
            this.entryHeight = IntUtil.Random(heightRange[0], this.actualHeight);
            this.topHeight = this.entryHeight;
        }
        if(this.exitWidth != 0){
            this.exitHeight = IntUtil.Random(heightRange[0],this.actualHeight);
        }

        if (topWidth > Valley.width[0])
        {
            topIsValley = true;
            valley = new Valley();
        }
    }

    public Mountain Mutate(float noice){
        Mountain mutation = new Mountain();
        double factor = DoubleUtil.Random(1-noice, 1+noice);
        mutation.entryHeight = Mathf.Clamp((int)(this.entryHeight * factor), heightRange[0], heightRange[1]);
        factor = DoubleUtil.Random(1-noice, 1+noice);
        mutation.exitHeight = Mathf.Clamp((int)(this.exitHeight * factor), heightRange[0], heightRange[1]); 

        mutation.topWidth = this.topWidth;
        mutation.exitWidth = this.exitWidth;
        mutation.entryWidth = this.entryWidth;
        // mutation.actualHeight = this.actualHeight;
        // mutation.actualWidth = this.actualWidth;
        // factor = DoubleUtil.Random(1-noice, 1+noice);
        // mutation.topWidth = Mathf.Clamp((int)(this.topWidth * factor), widthRange[0], widthRange[1]);
        // factor = DoubleUtil.Random(1-noice, 1+noice);
        // mutation.exitWidth = Mathf.Clamp((int)(this.exitWidth * factor), widthRange[0], widthRange[1]);
        // factor = DoubleUtil.Random(1-noice, 1+noice);
        // mutation.entryWidth = Mathf.Clamp((int)(this.entryWidth * factor), widthRange[0], widthRange[1]);

        if (mutation.topWidth > Valley.width[0])
        {
            mutation.topIsValley = true;
            factor = DoubleUtil.Random(1-noice, 1+noice);            ;
            mutation.valley = new Valley(Mathf.Clamp((int)(this.valley.noTrees * factor),Tree.spawn[0],Tree.spawn[1]));
        }
        return mutation;
    }

    public void Draw(GameObject block){        
        this.mountain = new GameObject("Mountain");
        this.mountain.transform.SetParent(block.transform);
        Vector3 lastPos = AppController.LastEnd;
        Vector3 pos = new Vector3(lastPos.x+(float)(this.entryWidth)/2.0f,lastPos.y+(float)(this.entryHeight)/2.0f,0);
        Vector3 scale = new Vector3((float)this.entryWidth/AppController.spriteScale,(float)this.entryHeight/AppController.spriteScale,1/AppController.spriteScale);
        
        if(this.entryWidth != 0){
            Entry = AppController.Draw(AppController.EntryPrefab, pos, scale, this.mountain.transform);
            lastPos.x += this.entryWidth;
            lastPos.y += this.entryHeight;

            Ground(Entry.transform, (float)(this.entryWidth)/2.0f, 0);
        }
        AppController.LastEnd = lastPos;   

        pos = new Vector3(lastPos.x+(float)(this.topWidth)/2.0f,lastPos.y-(float)(this.topHeight)/2.0f,0);
        scale = new Vector3((float)this.topWidth/AppController.spriteScale,(float)this.topHeight/AppController.spriteScale,1/AppController.spriteScale);
        
        GameObject topPrefab = AppController.TopPrefab;
        if(topIsValley){
            topPrefab = AppController.ValleyPrefab;
        }        
        Top = AppController.Draw(topPrefab, pos, scale, this.mountain.transform);
        lastPos.x += this.topWidth;        
        
        Ground(Top.transform, (float)(this.topWidth)/2.0f, (float)(this.topHeight));
        AppController.LastEnd = lastPos;

        if(topIsValley){
            valley.Draw(this.topWidth, Top.transform);
        }

        if(this.exitWidth != 0){
            pos = new Vector3(lastPos.x+(float)(this.exitWidth)/2.0f,lastPos.y-(float)(this.exitHeight)/2.0f,0);
            scale = new Vector3((float)this.exitWidth/AppController.spriteScale,(float)this.exitHeight/AppController.spriteScale,1/AppController.spriteScale);
            Exit = AppController.Draw(AppController.ExitPrefab, pos, scale, this.mountain.transform);
            lastPos.x += this.exitWidth;
            lastPos.y -= this.exitHeight;

            Ground(Exit.transform, (float)(this.exitWidth)/2.0f, (float)(this.exitHeight));
        }
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