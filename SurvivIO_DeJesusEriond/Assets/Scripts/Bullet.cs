using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private int _damage;

    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
