using UnityEngine;

public class Player : Unit
{
    public int CurrentPistolAmmo
    {
        get => _currentPistolAmmo;
        set => _currentPistolAmmo = value;
    }

    public int MaxPistolAmmo
    {
        get => _maxPistolAmmo;
        private set => _maxPistolAmmo = value;
    }

    public int CurrentAutomaticAmmo
    {
        get => _currentAutomaticAmmo;
        set => _currentAutomaticAmmo = value;
    }

    public int MaxAutomaticAmmo
    {
        get => _maxAutomaticAmmo;
        private set => _maxAutomaticAmmo = value;
    }

    public int CurrentShotgunAmmo
    {
        get => _currentShotgunAmmo;
        set => _currentShotgunAmmo = value;
    }

    public int MaxShotgunAmmo
    {
        get => _maxShotgunAmmo;
        private set => _maxShotgunAmmo = value;
    }

    private int _currentPistolAmmo;
    private int _maxPistolAmmo;
    private int _currentAutomaticAmmo;
    private int _maxAutomaticAmmo;
    private int _currentShotgunAmmo;
    private int _maxShotgunAmmo;

    private void Awake()
    {
        CurrentHealth = 80;
        MaxHealth = 100;

        MovementSpeed = 5;
        RotationSpeed = 3;

        MaxPistolAmmo = 90;
        MaxAutomaticAmmo = 120;
        MaxShotgunAmmo = 60;
    }
}
