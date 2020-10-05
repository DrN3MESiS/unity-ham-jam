using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    List<Block> EntityController;

    void Start()
    {
        Block initBlock = Instantiate(new Block());
        int err = initBlock.Generate();
        if (err != 0)
        {
            Debug.LogError("Couldn't generate block!");
            Application.Quit(-1);
        }
    }
}
