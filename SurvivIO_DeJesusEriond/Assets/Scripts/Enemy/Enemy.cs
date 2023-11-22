using UnityEngine;

public class Enemy : Unit
{
    private void Awake()
    {
        CurrentHealth = 50;
        MaxHealth = 100;

        MovementSpeed = 5;
        RotationSpeed = 3;
    }
}
