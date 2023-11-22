using UnityEngine;

[System.Serializable]
public class Weapon
{
    public AmmoType _ammoType;

    public int _damage;

    public float _fireRate;
    public float _spread;

    public int _clipCapacity;
    [HideInInspector] public int _currentClip;

    public void Initialize(AmmoType ammo, float fireRate, float spread, int damage, int clipCapacity)
    {
        _ammoType = ammo;
        _fireRate = fireRate;
        _spread = spread;
        _damage = damage;
        _clipCapacity = clipCapacity;
    }
}
