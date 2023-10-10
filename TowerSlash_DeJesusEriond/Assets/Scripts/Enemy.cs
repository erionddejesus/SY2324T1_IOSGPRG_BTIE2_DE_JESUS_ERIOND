using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Player>())
        {
            enemyRigidBody.simulated = false;
        }
    }

    public void DisableRigidbody()
    {
        enemyRigidBody.simulated = false;
    }
}
