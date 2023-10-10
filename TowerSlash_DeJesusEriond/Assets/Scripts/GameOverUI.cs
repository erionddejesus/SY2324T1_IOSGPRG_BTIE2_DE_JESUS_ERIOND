using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.currentScore > GameManager.Instance.highScore)
        {
            GameManager.Instance.highScore = GameManager.Instance.currentScore;
        }

        currentScoreText.text = "Current Score: " + GameManager.Instance.currentScore;
        highScoreText.text = "High Score: " + GameManager.Instance.highScore;
    }

    public void Retry()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
}
