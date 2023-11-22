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
        StartCoroutine(CO_Die());
    }

    private void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>())
        {
            collider.GetComponent<Health>().TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    private IEnumerator CO_Die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
