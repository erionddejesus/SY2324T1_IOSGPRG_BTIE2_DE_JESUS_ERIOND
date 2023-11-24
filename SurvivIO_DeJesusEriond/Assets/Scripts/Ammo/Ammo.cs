using UnityEngine;

public enum AmmoType
{
    Bullet,
    Grenade
}

[System.Serializable]
public class Ammo
{
    public GunType _gunType;

    public int _maxAmmo;
    [HideInInspector] public int _currentAmmo;
}
