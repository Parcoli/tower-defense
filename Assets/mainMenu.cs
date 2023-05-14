
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   
   // public PauseMenu PauseMenu;
    void Play()
    {
       
        
       SceneManager.LoadScene("Level01"); 
    }

    // Update is called once per frame
    void Quit()
    {
      
        Application.Quit();
    }
}
