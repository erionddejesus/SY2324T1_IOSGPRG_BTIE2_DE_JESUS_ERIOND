using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    // Player stats
    private int maxLives;
    private int currentLives;

    private int speed;
    private int dashAmount;

    private float maxDashGauge;
    private float currentDashGauge;

    private bool isDashing;
    private bool isTapDashing;

    // Touch controls
    private Vector2 initialTouchPosition;
    private Vector2 endTouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;

        speed = 1;

        maxDashGauge = 100;
        currentDashGauge = 100;

        isDashing = false;
        isTapDashing = false;
    }

    // Check if player collides with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if (!isDashing)
            {
                DecreaseLives();
            }
            else
            {
                IncreaseDashGauge();
                Powerup();
            }
        }
    }

    // Check if player is in range of enemy
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>())
        {
            collider.GetComponentInChildren<Arrow>().SetInRange();
            enemies.Add(collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Player continously moving upwards
        transform.Translate(speed * Time.deltaTime * Vector3.up);

        // Touch controls
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            initialTouchPosition = touch.position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Touch touch = Input.GetTouch(0);
            endTouchPosition = touch.position;

            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        float xDistance = Mathf.Abs(initialTouchPosition.x - endTouchPosition.x);
        float yDistance = Mathf.Abs(initialTouchPosition.y - endTouchPosition.y);

        // Check if tap (dash)
        if (xDistance < 1 || yDistance < 1)
        {
            // Dash if there's no enemy in range
            if (enemies.Count == 0 && !isDashing && !isTapDashing)
            {
                AddScore(5);
                StartCoroutine(CO_TapDash());
            }

            return;
        }

        int swipeDirection;

        // Check swipe direction
        if (xDistance > yDistance)
        {
            if (initialTouchPosition.x < endTouchPosition.x)
            {
                swipeDirection = 3; // Right
            }
            else
            {
                swipeDirection = 2; // Left
            }
        }
        else
        {
            if (initialTouchPosition.y < endTouchPosition.y)
            {
                swipeDirection = 0; // Up
            }
            else
            {
                swipeDirection = 1; // Down
            }
        }

        if (enemies.Count != 0)
        {
            if (swipeDirection != enemies[0].GetComponentInChildren<Arrow>().GetArrowDirection())
            {
                DecreaseLives();
            }
            else
            {
                IncreaseDashGauge();
                Powerup();
            }
        }
    }

    private void DecreaseLives()
    {
        currentLives--;

        enemies[0].GetComponent<Enemy>().DisableRigidbody();
        enemies.Remove(enemies[0]);

        if (currentLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Powerup()
    {
        AddScore(10);

        Destroy(enemies[0]);
        enemies.Remove(enemies[0]);

        if (Random.Range(0, 100) < 3) // 3% chance
        {
            currentLives++;

            if (currentLives > maxLives)
            {
                currentLives = maxLives;
            }
        }
    }

    private void IncreaseDashGauge()
    {
        currentDashGauge += (dashAmount / maxDashGauge) * 100;

        if (currentDashGauge > maxDashGauge)
        {
            currentDashGauge = maxDashGauge;
        }
    }

    private IEnumerator CO_Dash()
    {
        currentDashGauge = 0;

        isDashing = true;
        Time.timeScale = 4.0f;

        yield return new WaitForSecondsRealtime(5.0f);
        isDashing = false;
        Time.timeScale = 1.0f;
    }

    private IEnumerator CO_TapDash()
    {
        isTapDashing = true;
        speed = 6;

        yield return new WaitForSeconds(0.2f);
        speed = 1;

        yield return new WaitForSeconds(2.0f);
        isTapDashing = false;
    }

    private void AddScore(int score)
    {
        GameManager.Instance.currentScore += score;
    }

    public void Dash()
    {
        StartCoroutine(CO_Dash());
    }

    public void SetMaxLives(int lives)
    {
        maxLives = lives;
    }

    public void SetDashAmount(int dash)
    {
        dashAmount = dash;
    }

    public int GetLives()
    {
        return currentLives;
    }

    public float GetMaxDashGauge()
    {
        return maxDashGauge;
    }

    public float GetCurrentDashGauge()
    {
        return currentDashGauge;
    }
}
