using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerController>())
        {
            IncreaseAmmo(collider.GetComponent<PlayerController>());
            Destroy(gameObject);
        }
    }

    protected virtual void IncreaseAmmo(PlayerController player)
    {
        Debug.Log("Increase Ammo");
    }
}
