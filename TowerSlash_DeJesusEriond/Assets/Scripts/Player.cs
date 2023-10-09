using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;

    // Player stats
    private int maxLives;
    private int currentLives;

    private float maxDashGauge;
    private float currentDashGauge;

    private int speed;

    private bool isAttacking;
    private bool isDashing;
    private bool isTapDashing;

    private bool enemyAlive;

    // Arrow direction
    private int arrowColor;
    private int arrowDirection;

    private int correctArrowDirection;

    private bool correctSwipe;

    // Touch controls
    private float deadZone;

    private Vector2 initialTouchPosition;
    private Vector2 endTouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        maxLives = 3; // Will either be 3 or 5 depending on character selected
        currentLives = maxLives;

        maxDashGauge = 100;
        currentDashGauge = 100;

        speed = 1;

        isAttacking = false;
        isDashing = false;

        correctSwipe = false;

        deadZone = 1.0f;
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

                Destroy(collision.gameObject);
            }
        }
    }

    // Check if player is in range of enemy
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>())
        {
            enemyAlive = true;

            collider.GetComponentInChildren<Arrow>().SetInRange(true);

            arrowColor = collider.GetComponentInChildren<Arrow>().GetArrowColor();
            arrowDirection = collider.GetComponentInChildren<Arrow>().GetArrowDirection();

            CheckArrowDirection();
        }
    }

    // Check if player is attacking
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Enemy>())
        {
            if (isAttacking)
            {
                if (!correctSwipe)
                {
                    DecreaseLives();

                    collider.GetComponent<Enemy>().DisableRigidbody();
                }
                else
                {
                    IncreaseDashGauge();
                    Powerup();

                    Destroy(collider.gameObject);
                }
            }
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
        if (xDistance < deadZone || yDistance < deadZone)
        {
            // Dash if there's no enemy in range
            if (!enemyAlive && !isDashing && !isTapDashing)
            {
                StartCoroutine(CO_TapDash());
            }

            return;
        }

        // Check swipe direction
        if (xDistance > yDistance)
        {
            if (initialTouchPosition.x < endTouchPosition.x)
            {
                // Right
                StartCoroutine(CO_Attack(3));
                Debug.Log("right");
            }
            else
            {
                // Left
                StartCoroutine(CO_Attack(2));
                Debug.Log("left");
            }
        }
        else
        {
            if (initialTouchPosition.y < endTouchPosition.y)
            {
                // Up
                StartCoroutine(CO_Attack(0));
                Debug.Log("up");
            }
            else
            {
                // Down
                StartCoroutine(CO_Attack(1));
                Debug.Log("down");
            }
        }
    }

    private void CheckArrowDirection()
    {
        // Up = 0, Down = 1, Left = 2, Right = 3
        if (arrowColor == 0)
        {
            correctArrowDirection = arrowDirection;
        }
        // Opposite direction
        else
        {
            switch (arrowDirection)
            {
                case 0:
                    correctArrowDirection = 1;
                    break;
                case 1:
                    correctArrowDirection = 0;
                    break;
                case 2:
                    correctArrowDirection = 3;
                    break;
                case 3:
                    correctArrowDirection = 2;
                    break;
            }
        }
    }

    private IEnumerator CO_Attack(int swipeDirection)
    {
        if (!enemyAlive)
        {
            yield break;
        }

        isAttacking = true;

        // Check if swipe direction is correct
        if (correctArrowDirection == swipeDirection)
        {
            correctSwipe = true;
        }
        else
        {
            correctSwipe = false;
        }

        yield return new WaitForSeconds(0.1f);
        isAttacking = false;
    }

    private void DecreaseLives()
    {
        enemyAlive = false;

        currentLives--;

        if (currentLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Powerup()
    {
        // 3% chance
        int randomValue = Random.Range(0, 100);

        if (randomValue < 3)
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
        enemyAlive = false;

        currentDashGauge += (5 / maxDashGauge) * 100; // +5% (will change depending on which character is selected)

        if (currentDashGauge > maxDashGauge)
        {
            currentDashGauge = maxDashGauge;
        }
    }

    private IEnumerator CO_Dash()
    {
        currentDashGauge = 0;

        isDashing = true;
        speed = 6;

        yield return new WaitForSeconds(5.0f);
        isDashing = false;
        speed = 1;
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

    public void Dash()
    {
        StartCoroutine(CO_Dash());
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
