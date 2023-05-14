using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver = false;

    public GameObject gameOverUI;

    private Scores scores;

    private void Start()
    {
        gameIsOver = false;
    }
    void Update()
    {

        if(PlayerStats.lives <= 0)
        {
            if(gameIsOver)
            {
                return;
            }
            EndGame();
        }
        
    }

    private void EndGame()
    {
        Scores.setScore();
        gameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
