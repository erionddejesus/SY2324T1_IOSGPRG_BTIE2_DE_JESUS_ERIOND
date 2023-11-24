using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage
    {
        set => _damage = value;
    }
    
    protected int _damage;

    [SerializeField] private float _lifespan;

    private void Start()
    {
        StartCoroutine(CO_DestroyBullet(_lifespan));
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            return;
        }

        if (collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }

        DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private IEnumerator CO_DestroyBullet(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        DestroyBullet();
    }
}
