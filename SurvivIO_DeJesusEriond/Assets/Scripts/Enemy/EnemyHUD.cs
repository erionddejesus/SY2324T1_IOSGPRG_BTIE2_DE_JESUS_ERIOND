using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    [SerializeField] private EnemyController _enemy;

    [SerializeField] private Slider _enemyHealthBar;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _enemyHealthBar.value = Mathf.Lerp(_enemyHealthBar.value, _enemy.CurrentHealth / _enemy.MaxHealth, 5 * Time.deltaTime);

        transform.rotation = _camera.transform.rotation;
    }
}
