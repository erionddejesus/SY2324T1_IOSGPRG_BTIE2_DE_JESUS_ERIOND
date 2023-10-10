using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer arrowSprite;
    [SerializeField] private Sprite[] sprites;

    private bool inRange;

    private int arrowDirection;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;

        arrowDirection = Random.Range(0, sprites.Length);

        // 20 percent chance to be a rotating arrow
        if (Random.Range(1, 6) == 1)
        {
            StartCoroutine(CO_RandomArrow());
        }
        else
        {
            DisplayArrow(Random.Range(0, 2));
        }
    }

    public void SetInRange()
    {
        inRange = true;
        transform.localScale = transform.localScale * 1.3f;
    }

    private void DisplayArrow(int arrowColor)
    {
        arrowSprite.sprite = sprites[arrowDirection];

        if (arrowColor == 0)
        {
            arrowSprite.color = Color.green;
        }
        else
        {
            arrowSprite.color = Color.red;

            switch (arrowDirection)
            {
                case 0:
                    arrowDirection = 1;
                    break;
                case 1:
                    arrowDirection = 0;
                    break;
                case 2:
                    arrowDirection = 3;
                    break;
                case 3:
                    arrowDirection = 2;
                    break;
            }
        }
    }

    private IEnumerator CO_RandomArrow()
    {
        arrowSprite.color = Color.yellow;

        while (!inRange)
        {
            yield return new WaitForSeconds(0.3f);
            arrowSprite.sprite = sprites[Random.Range(0, sprites.Length)];
        }

        DisplayArrow(0);
    }

    public int GetArrowDirection()
    {
        return arrowDirection;
    }
}
