using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool IsVictorious
    {
        get => _isVictorious;
        set => _isVictorious = value;
    }

    private bool _isVictorious;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
