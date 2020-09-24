using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    List<Block> GameApp;

    void Start()
    {

        GameApp = new List<Block>();
        Block initBlock = new Block();
        initBlock.Entities.Add(new Mountain(6, 8, 2));
        initBlock.Entities.Add(new Mountain(6, 8, 2));
        initBlock.Entities.Add(new Mountain(6, 8, 2));
        initBlock.Entities.Add(new Mountain(6, 8, 2));
        initBlock.Entities.Add(new Mountain(6, 8, 2));
        initBlock.Entities.Add(new Mountain(6, 8, 2));
        initBlock.Entities.Add(new Mountain(6, 8, 2));

        GameApp.Add(initBlock);
    }
}
