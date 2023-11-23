using UnityEngine;

[System.Serializable]
public class Weapon
{
    public AmmoType _ammoType;

    public float _fireRate;
    public float _reloadSpeed;
    public float _spread;
    public int _bullets;
    public int _damage;

    public int _clipCapacity;
    [HideInInspector] public int _currentClip;

    public void Initialize(AmmoType ammo, float fireRate, float reloadSpeed, float spread, int bullets, int damage, int clipCapacity)
    {
        _ammoType = ammo;
        _fireRate = fireRate;
        _reloadSpeed = reloadSpeed;
        _spread = spread;
        _damage = damage;
        _bullets = bullets;
        _clipCapacity = clipCapacity;
    }
}
