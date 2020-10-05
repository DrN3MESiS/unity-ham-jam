using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    List<GameObject> EntityController;

    void Start()
    {
        GameObject initBlock = Instantiate(new GameObject());

        Block _blockScript = initBlock.AddComponent<Block>();
        int err = _blockScript.Generate();
        if (err != 0)
        {
            Debug.LogError("Couldn't generate block!");
            Application.Quit(-1);
        }

    }
}
