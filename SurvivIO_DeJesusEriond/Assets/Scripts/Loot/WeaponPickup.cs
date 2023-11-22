using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] private WeaponSlot _slot;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _spread;
    [SerializeField] private int _damage;
    [SerializeField] private int _clipCapacity;

    protected override void Loot(Inventory inventory)
    {
        Weapon weapon = new Weapon();
        weapon.Initialize(_ammoType, _fireRate, _spread, _damage, _clipCapacity);

        inventory.AddWeapon(_slot, weapon);
        inventory.ChangeWeapon((int)_slot);
    }
}
