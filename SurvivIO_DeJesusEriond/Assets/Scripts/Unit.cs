using UnityEngine;

public class Unit : MonoBehaviour
{
    public float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    protected int MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }

    protected int RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    }

    private float _currentHealth;
    private float _maxHealth;

    private int _movementSpeed;
    private int _rotationSpeed;
}
