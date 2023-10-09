using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer arrowSprite;
    [SerializeField] private Sprite[] sprites;

    private bool inRange;

    private int arrowColor;
    private int arrowDirection;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;

        arrowColor = Random.Range(0, 2);
        arrowDirection = Random.Range(0, sprites.Length);

        // Decides if the arrow is a rotating arrow
        if (Random.Range(0, 2) == 0)
        {
            StartCoroutine(CO_RandomArrow());
        }
        else
        {
            DisplayArrow();
        }
    }

    public void SetInRange(bool range)
    {
        inRange = range;
    }

    private void DisplayArrow()
    {
        arrowSprite.sprite = sprites[arrowDirection];

        if (arrowColor == 0)
        {
            arrowSprite.color = Color.green;
        }
        else
        {
            arrowSprite.color = Color.red;
        }
    }

    private IEnumerator CO_RandomArrow()
    {
        while (!inRange)
        {
            yield return new WaitForSeconds(0.3f);
            arrowSprite.sprite = sprites[Random.Range(0, sprites.Length)];
        }

        DisplayArrow();
    }

    public int GetArrowColor()
    {
        return arrowColor;
    }

    public int GetArrowDirection()
    {
        return arrowDirection;
    }
}
