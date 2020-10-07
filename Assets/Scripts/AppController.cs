using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    List<GameObject> BlockController = new List<GameObject>();
    List<Block> BlockScripts = new List<Block>();
    public Sprite [] sprites = new Sprite [5];
    void Start()
    {

        GameObject initBlock = new GameObject("Block_");
        
        Block _blockScript = initBlock.AddComponent<Block>();
        BlockController.Add(initBlock);
        BlockScripts.Add(_blockScript);
        Debug.Log("heeeeeeeeeeeeeeeeeeeeeeei");
        StartCoroutine(waiter());
        
    }

    void showMountains(){
        int x = 0;
        
        for(int num = 0; num < BlockScripts.Count; num++){
            int size = BlockScripts[num].Scripts.Count;
            List<Mountain> mountains = BlockScripts[num].Scripts;
            for (int i = 0; i < size; i++){
                Sprite entry = sprites[IntUtil.Random(0, sprites.Length)];
                Sprite exit = sprites[IntUtil.Random(0, sprites.Length)];
                SpriteRenderer ENTRY = mountains[i].Entry.AddComponent<SpriteRenderer>() as SpriteRenderer;
                SpriteRenderer EXIT = mountains[i].Exit.AddComponent<SpriteRenderer>() as SpriteRenderer;
                ENTRY.sprite = entry; 
                EXIT.sprite = exit;
                EXIT.flipX = true;

                GameObject entrada = mountains[i].Entry;
                entrada.gameObject.transform.localScale -= new Vector3(0.9f, 0.9f, 0);
                GameObject salida = mountains[i].Exit;
                salida.gameObject.transform.localScale -= new Vector3(0.9f, 0.9f, 0);
                if (mountains[i].entryWidth > 0){
                    entrada.transform.position = new Vector3(x,0,0);
                    x += mountains[i].entryWidth;
                }

                if (mountains[i].exitWidth > 0){
                    salida.transform.position = new Vector3(x,0,0);
                    x += mountains[i].exitWidth;
                }
                
                
            }
        }
            
        }

        IEnumerator waiter()
        {   
            yield return new WaitForSeconds(2);
            showMountains();
            
        }
        
    }
