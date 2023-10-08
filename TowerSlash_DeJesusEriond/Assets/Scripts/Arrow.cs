using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer arrowSprite;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Rigidbody2D enemyRigidbody;

    private bool inRange;

    private int arrowColor;
    private int arrowDirection;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;

        arrowDirection = Random.Range(0, sprites.Length);
        arrowColor = Random.Range(0, 2);

        // Decides if the arrow is a rotating arrow
        if (Random.Range(0, 2) == 0)
        {
            StartCoroutine(RandomArrow());
        }
        else
        {
            DisplayArrow();
        }
    }

    // Destroys parent object when in range and swipe direction is correct
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (GameManager.Instance.GetIsAttacking() && enemyRigidbody.simulated)
            Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        inRange = true;

        ArrowDirection();
    }

    private void DisplayArrow()
    {
        arrowSprite.sprite = sprites[arrowDirection];

        if (arrowColor == 0)
            arrowSprite.color = Color.green;
        else
            arrowSprite.color = Color.red;
    }

    private IEnumerator RandomArrow()
    {
        while (!inRange)
        {
            yield return new WaitForSeconds(0.3f);
            arrowSprite.sprite = sprites[Random.Range(0, sprites.Length)];
        }

        DisplayArrow();
    }

    private void ArrowDirection()
    {
        // Up = 0, Down = 1, Left = 2, Right = 3
        if (arrowColor == 0)
        {
            GameManager.Instance.SetDirection(arrowDirection);
        }
        // Opposite direction
        else
        {
            switch (arrowDirection)
            {
                case 0:
                    GameManager.Instance.SetDirection(1);
                    break;
                case 1:
                    GameManager.Instance.SetDirection(0);
                    break;
                case 2:
                    GameManager.Instance.SetDirection(3);
                    break;
                case 3:
                    GameManager.Instance.SetDirection(2);
                    break;
            }
        }
    }
}
