using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public KeyCode restart = KeyCode.R;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(restart)){
            RestartScene();
        }        
    }
    
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
