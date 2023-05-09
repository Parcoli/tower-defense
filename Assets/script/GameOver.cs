using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Direction le menu principal");
    }
}
