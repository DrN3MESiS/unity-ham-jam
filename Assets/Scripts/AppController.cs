using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    List<GameObject> BlockController = new List<GameObject>();
    List<Block> BlockScripts = new List<Block>();
    public Sprite[] sprites = new Sprite[5];
    public Sprite[] valleySprites = new Sprite[3];

    public Vector3 startReference = new Vector3(0, 0, 0);

    public GameObject BlockPrefab;
    public GameObject MountainSetTestPrefab;
    public GameObject MountainEntryPrefab;
    public GameObject MountainTopPrefab;
    public GameObject MountainExitPrefab;
    public GameObject ValleyPrefab;
    public GameObject TreePrefab;

    IEnumerator GenerateGame()
    {
        for (int i = 0; i < 5; i++)
        {
            // GameObject tempBlock = ObjectGenerator.GenerateBlock(i, startReference);
            GameObject tempBlock = ObjectGenerator.GenerateBlock(i, startReference, BlockPrefab);
            Block blockScript = tempBlock.GetComponent<Block>();
            BlockController.Add(tempBlock);

            yield return new WaitForSeconds(2);
            startReference = new Vector3(startReference.x + Mathf.Abs(blockScript.unitsLeft - 100), startReference.y, startReference.z);
        }
    }
    void Start()
    {
        gameObject.tag = "Controller";
        StartCoroutine(GenerateGame());
        // manualMountains();

        // StartCoroutine(waiter());
    }

    // void createPart(GameObject parte, float x, float y, bool itFlip, float scaleX, float scaleY)
    // {
    //     parte.gameObject.transform.localScale -= new Vector3(0.9f, 0.9f, 0);
    //     Sprite entry = sprites[IntUtil.Random(0, sprites.Length)];
    //     parte.gameObject.transform.localScale += new Vector3(scaleX / 10, scaleY / 10, 0);
    //     SpriteRenderer ENTRY = parte.AddComponent<SpriteRenderer>() as SpriteRenderer;
    //     ENTRY.sprite = entry;
    //     if (itFlip) ENTRY.flipX = true;
    //     parte.transform.position = new Vector3(x, y, 0);
    // }

    // void createValley(GameObject valley, float x, float y, float scaleX, float scaleY)
    // {
    //     valley.gameObject.transform.localScale -= new Vector3(0.904f, 0.904f, 0);
    //     Sprite entry = valleySprites[IntUtil.Random(0, valleySprites.Length)];
    //     valley.gameObject.transform.localScale += new Vector3(scaleX / 10, scaleY / 10, 0);
    //     SpriteRenderer ENTRY = valley.AddComponent<SpriteRenderer>() as SpriteRenderer;
    //     ENTRY.sprite = entry;
    //     valley.transform.position = new Vector3(x, y, 0);
    // }

    // void manualMountains()
    // {

    //     int x = 0;
    //     int y = 0;
    //     // 1ra montaña
    //     createPart(new GameObject(), x, y, false, 0.0f, 0.0f);

    //     createValley(new GameObject(), x + 1, y + .25f, 0.0f, 0.0f);

    //     createPart(new GameObject(), x + 2, y, true, 0.0f, 0.0f);

    //     // 2da montaña
    //     createPart(new GameObject(), x + 3 + 0.1f, y + 0.1f, false, 0.2f, 0.2f);

    //     createValley(new GameObject(), x + 4 + 0.3f, y + .25f + 0.15f, 0.2f, 0.2f);

    //     createPart(new GameObject(), x + 5 + 0.4f, y + 0.2f, true, 0.0f, 0.0f);

    //     // 3ra montaña
    //     createPart(new GameObject(), x + 6 + 0.6f, y + .40f, false, 0.4f, 0.4f);

    //     createValley(new GameObject(), x + 7 + 0.7f + 0.3f, y + .60f + 0.15f, 0.4f, 0.4f);

    //     // 4ta montaña
    //     createPart(new GameObject(), x + 8 + 1.2f, y + 1.7f, false, 0.4f, 0.4f);

    //     createValley(new GameObject(), x + 9 + 1.3f + 0.3f, y + 1.9f + 0.15f, 0.4f, 0.4f);
    // }


    // void showMountains()
    // {
    //     int x = 0;

    //     for (int num = 0; num < BlockScripts.Count; num++)
    //     {
    //         int size = BlockScripts[num].Scripts.Count;
    //         List<Mountain> mountains = BlockScripts[num].Scripts;
    //         for (int i = 0; i < size; i++)
    //         {



    //             GameObject entrada = mountains[i].Entry;
    //             entrada.gameObject.transform.localScale -= new Vector3(0.9f, 0.9f, 0);
    //             GameObject salida = mountains[i].Exit;
    //             salida.gameObject.transform.localScale -= new Vector3(0.9f, 0.9f, 0);
    //             GameObject top_ = mountains[i].Top;
    //             top_.gameObject.transform.localScale -= new Vector3(0.8f, 0.8f, 0);
    //             if (mountains[i].entryWidth > 0)
    //             {
    //                 Sprite entry = sprites[IntUtil.Random(0, sprites.Length)];
    //                 SpriteRenderer ENTRY = mountains[i].Entry.AddComponent<SpriteRenderer>() as SpriteRenderer;
    //                 ENTRY.sprite = entry;
    //                 entrada.transform.position = new Vector3(x, 0, 0);
    //                 x += mountains[i].entryWidth;
    //             }

    //             if (mountains[i].topIsValley)
    //             {
    //                 Debug.Log("heeeeeeeeeeeeeeeeeeeeeeei");
    //                 Sprite top = valleySprites[IntUtil.Random(0, valleySprites.Length)];
    //                 SpriteRenderer TOP = mountains[i].Top.AddComponent<SpriteRenderer>() as SpriteRenderer;
    //                 TOP.sprite = top;
    //                 top_.transform.position = new Vector3(x, 0, 0);
    //                 x += mountains[i].topWidth;
    //             }

    //             if (mountains[i].exitWidth > 0)
    //             {
    //                 Sprite exit = sprites[IntUtil.Random(0, sprites.Length)];
    //                 SpriteRenderer EXIT = mountains[i].Exit.AddComponent<SpriteRenderer>() as SpriteRenderer;

    //                 EXIT.sprite = exit;
    //                 EXIT.flipX = true;
    //                 salida.transform.position = new Vector3(x, 0, 0);
    //                 x += mountains[i].exitWidth;
    //             }


    //         }
    //     }

    // }

    // IEnumerator waiter()
    // {
    //     yield return new WaitForSeconds(2);
    //     showMountains();

    // }

}
