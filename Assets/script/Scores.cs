using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scores : MonoBehaviour
{
    [HideInInspector][SerializeField]
    private static int playerCount;

    public Text playersText;
    // Start is called before the first frame update
    void Start()
    {
        playerCount = PlayerPrefs.GetInt("playerCount", 0);
        getData();
    }

    public static void setPseudo(string pseudo)
    {

        playerCount++;
        PlayerPrefs.SetInt("playerCount", playerCount);
        PlayerStats.pseudo = pseudo;
        PlayerPrefs.SetString("playerName " + playerCount.ToString(), PlayerStats.pseudo);
    }

    public static void setScore()
    {
        PlayerPrefs.SetInt("playerScore " + playerCount.ToString(), PlayerStats.rounds);

    }

    public void getData()
    {
        string players = "";
        for (int i = 1; i <= PlayerPrefs.GetInt("playerCount", 0); i++)
        {
            string name = PlayerPrefs.GetString("playerName " + i, "Unknown");
            int score = PlayerPrefs.GetInt("playerScore " + i, 0);
            players += name + ": " + score + " vagues\n";
        }
        // Display the list of players in a UI Text element
        playersText.text = players;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
