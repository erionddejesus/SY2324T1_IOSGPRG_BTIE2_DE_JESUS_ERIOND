using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Slider _healthBar;

    protected virtual void UpdateHealthBar()
    {
        _healthBar.value = Mathf.Lerp(_healthBar.value, _health.CurrentHealth / _health.MaxHealth, 5 * Time.deltaTime);
    }
}
