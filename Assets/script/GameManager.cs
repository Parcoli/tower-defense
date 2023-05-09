using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;
    void Update()
    {
        if(PlayerStats.lives <= 0)
        {
            if(gameEnded)
            {
                return;
            }
            EndGame();
        }
        
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over !");
    }
}
