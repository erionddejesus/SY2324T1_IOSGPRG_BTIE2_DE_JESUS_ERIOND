using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int Damage
    {
        set => _damage = value;
    }

    private int _damage;

    [SerializeField] private float _lifespan;

    private void Start()
    {
        StartCoroutine(CO_Destroy(_lifespan));
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().TakeDamage(_damage);
        }
    }

    private IEnumerator CO_Destroy(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
