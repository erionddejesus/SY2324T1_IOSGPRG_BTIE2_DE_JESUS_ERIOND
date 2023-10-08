using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;

    // Player stats
    private int maxLives;
    private int currentLives;

    private int speed;

    private bool isAlive;

    // Touch controls
    private Vector2 initialTouchPosition;
    private Vector2 endTouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.SetIsAttacking(false);

        isAlive = true;

        maxLives = 3; // Will either be 3 or 5 depending on character selected
        currentLives = maxLives;

        speed = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.Instance.GetIsAttacking())
            currentLives--;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives == 0)
            isAlive = false;

        if (!isAlive)
            Destroy(gameObject);

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

        // Swipe direction
        // Up = 0, Down = 1, Left = 2, Right = 3
        if (xDistance > yDistance)
        {
            if (initialTouchPosition.x < endTouchPosition.x)
            {
                Debug.Log("Swiped Right");
                StartCoroutine(Attack(3));
            }
            else
            {
                Debug.Log("Swiped Left");
                StartCoroutine(Attack(2));
            }
        }
        else
        {
            if (initialTouchPosition.y < endTouchPosition.y)
            {
                Debug.Log("Swiped Up");
                StartCoroutine(Attack(0));
            }
            else
            {
                Debug.Log("Swiped Down");
                StartCoroutine(Attack(1));
            }
        }
    }

    private IEnumerator Attack(int direction)
    {
        // Check if swipe direction is correct
        if (GameManager.Instance.GetDirection() == direction)
            GameManager.Instance.SetIsAttacking(true);

        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.SetIsAttacking(false);
    }

    public int GetLives()
    {
        return currentLives;
    }
}
