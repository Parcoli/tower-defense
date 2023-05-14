using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public SceneFader fader;
   
    // Start is called before the first frame update
    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
        PlayerStats.roundsSurived = PlayerStats.rounds;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}
