using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    private bool IsPaused = false;
    private GameObject[] PauseObjs;
    private void Start()
    {
        PauseObjs = GameObject.FindGameObjectsWithTag("Pause");
        Un_Pause();
    }
    public void Game()
    {
        SceneManager.LoadScene("Scene02");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Scene02");
        //SceneManager.LoadScene(Application.loadedLevel);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }
    public void Death()
    {
        SceneManager.LoadScene("Death");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && IsPaused)
        {
            Time.timeScale = 1;
            Un_Pause();
            IsPaused = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !IsPaused)
        {
            Time.timeScale = 0;
            Pause();
            IsPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    private void Pause()
    {
        foreach (GameObject g in PauseObjs)
        {
            g.SetActive(true);
        }
    }
    private void Un_Pause()
    {
        foreach (GameObject g in PauseObjs)
        {
            g.SetActive(false);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
