using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private Slider dashGauge;
    [SerializeField] private Button dashButton;

    private float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        lerpSpeed = 5.0f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + player.GetLives();

        dashGauge.value = Mathf.Lerp(dashGauge.value, player.GetCurrentDashGauge() / player.GetMaxDashGauge(), lerpSpeed);

        if (player.GetCurrentDashGauge() == player.GetMaxDashGauge())
        {
            dashButton.gameObject.SetActive(true);
        }
        else
        {
            dashButton.gameObject.SetActive(false);
        }
    }
}
