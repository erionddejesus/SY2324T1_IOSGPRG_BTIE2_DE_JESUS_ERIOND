using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] private int _minAmount;
    [SerializeField] private int _maxAmount;

    protected override void Loot(Inventory inventory)
    {
        inventory.IncreaseAmmo(_ammoType, Random.Range(_minAmount, _maxAmount));
    }
}
