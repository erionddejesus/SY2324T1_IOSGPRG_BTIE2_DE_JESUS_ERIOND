using UnityEngine;

public enum AmmoType
{
    Pistol,
    Automatic,
    Shotgun,
    None
}

[System.Serializable]
public class Ammo
{
    public AmmoType _ammoType;

    public int _maxAmmo;
    [HideInInspector] public int _currentAmmo;
}
