using TMPro;
using UnityEngine;

public class GameOverUI : UI
{
    [SerializeField] TextMeshProUGUI _gameOverText;
    [SerializeField] TextMeshProUGUI _retryText;

    private void Start()
    {
        if (!GameManager.instance.IsVictorious)
        {
            _gameOverText.text = "GAME OVER";
            _retryText.text = "RETRY";
        }
        else
        {
            _gameOverText.text = "WINNER! WINNER! CHICKEN DINNER!";
            _retryText.text = "PLAY AGAIN";
        }
    }
}
