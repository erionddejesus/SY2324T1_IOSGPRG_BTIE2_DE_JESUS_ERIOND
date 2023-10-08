using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private Player player;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + player.GetLives();
    }
}