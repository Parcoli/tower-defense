using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    public SceneFader fader;
    public string mainMenu = "";
    // Start is called before the first frame update
    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
        PlayerStats.roundsSurived = PlayerStats.rounds;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("Direction le menu principal");
        fader.FadeTo(mainMenu);
    }
}
