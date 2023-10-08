using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isAttacking;
    private int currentDirection;

    public bool GetIsAttacking()
    {
        return isAttacking;
    }

    public void SetIsAttacking(bool attack)
    {
        isAttacking = attack;
    }

    public int GetDirection()
    {
        return currentDirection;
    }

    public void SetDirection(int direction)
    {
        currentDirection = direction;
    }
}
