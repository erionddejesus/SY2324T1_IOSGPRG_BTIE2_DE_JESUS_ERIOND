using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage
    {
        set => _damage = value;
    }
    
    private int _damage;

    private void Start()
    {
        StartCoroutine(CO_DestroyBullet());
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

        Destroy(gameObject);
    }

    private IEnumerator CO_DestroyBullet()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
