using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuWork : MonoBehaviour
{
    private Scores score;
    public InputField input;
   
    public void Play(){
        SceneManager.LoadScene("Level01");
        return;
    }

   public void Quit(){
        Application.Quit();
    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene("ScoreBoard");
    }


    public void SubmitPseudo()
    {
        Scores.setPseudo(input.text);
    }


}

