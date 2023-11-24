using UnityEngine;

public class Grenade : Bullet
{
    [SerializeField] private GameObject _explosionPrefab;

    protected override void DestroyBullet()
    {
        GameObject explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().Damage = _damage;

        base.DestroyBullet();
    }
}
