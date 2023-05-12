using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public SceneFader fader;

    public string menuSceneName = "MainMenu";
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) )
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if(ui.activeSelf ) 
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Debug.Log("Chargement du menu");
        // fader.FadeTo(menuSceneName);
    }

}
