using UnityEngine;

public enum WeaponSlot
{
    Primary,
    Secondary
}

public class Inventory : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Weapon[] _weaponInventory;
    [SerializeField] private Ammo[] _ammoInventory;

    public int GetCurrentAmmo(GunType type)
    {
        return _ammoInventory[(int)type]._currentAmmo;
    }

    public string GetWeaponName(WeaponSlot slot)
    {
        return _weaponInventory[(int)slot]._gunType.ToString();
    }

    public void IncreaseAmmo(GunType type, int amount)
    {
        Ammo inventory = _ammoInventory[(int)type];

        inventory._currentAmmo += amount;
        inventory._currentAmmo = Mathf.Min(inventory._currentAmmo, inventory._maxAmmo);
    }

    public void DecreaseAmmo(GunType type, int amount)
    {
        Ammo inventory = _ammoInventory[(int)type];

        inventory._currentAmmo -= amount;
        inventory._currentAmmo = Mathf.Max(inventory._currentAmmo, 0);
    }

    public void AddWeapon(WeaponSlot slot, Weapon weapon)
    {
        _weaponInventory[(int)slot] = weapon;
    }

    public void ChangeWeapon(int slot)
    {
        _player.SetCurrentWeapon(_weaponInventory[slot], (int)_weaponInventory[slot]._gunType);
    }
}
