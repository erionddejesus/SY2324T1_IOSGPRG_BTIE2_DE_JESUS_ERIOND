using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] protected GunType _gunType;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            Loot(collider.GetComponent<Inventory>());
            Destroy(gameObject);
        }
    }

    protected virtual void Loot(Inventory inventory)
    {
        Debug.Log("Pickup");
    }
}
