using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [HideInInspector] public Player player;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Slider dashGauge;
    [SerializeField] private Button dashButton;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + player.GetLives();
        scoreText.text = "Score: " + GameManager.Instance.currentScore;

        dashGauge.value = Mathf.Lerp(dashGauge.value, player.GetCurrentDashGauge() / player.GetMaxDashGauge(), 5 * Time.deltaTime);

        if (player.GetCurrentDashGauge() == player.GetMaxDashGauge())
        {
            dashButton.gameObject.SetActive(true);
            dashButton.onClick.AddListener(player.Dash);
        }
        else
        {
            dashButton.gameObject.SetActive(false);
        }
    }
}
