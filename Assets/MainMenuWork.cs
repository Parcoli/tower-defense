
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWork : MonoBehaviour
{

   
    public void Play(){
        SceneManager.LoadScene("Level01");
        return;
    }

   public void Quit(){
        Application.Quit();
    }
}

