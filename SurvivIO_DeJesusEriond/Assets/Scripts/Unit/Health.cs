using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float MaxHealth
    {
        get => _maxHealth;
    }

    public float CurrentHealth
    {
        get => _currentHealth;
    }

    private float _currentHealth;
    private float _maxHealth;

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0);

        if (_currentHealth == 0)
        {
            if (GetComponent<Player>())
            {
                GameManager.instance.IsVictorious = false;
                SceneManager.LoadScene(2);
            }
            
            if (GetComponent<Boss>())
            {
                GetComponent<Boss>().DropLoot();
            }

            Destroy(gameObject);
        }
    }

    public void AddHealth(int amount)
    {
        _currentHealth -= amount;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
    }
}
