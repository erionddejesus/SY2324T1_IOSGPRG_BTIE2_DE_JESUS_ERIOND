using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    [SerializeField] private Slider _playerHealthBar;

    [SerializeField] private TextMeshProUGUI _pistolAmmoInventory;
    [SerializeField] private TextMeshProUGUI _automaticAmmoInventory;
    [SerializeField] private TextMeshProUGUI _shotgunAmmoInventory;

    private void Update()
    {
        if (_player)
        {
            _playerHealthBar.value = Mathf.Lerp(_playerHealthBar.value, _player.CurrentHealth / _player.MaxHealth, 5 * Time.deltaTime);

            _pistolAmmoInventory.text = _player.CurrentPistolAmmo.ToString();
            _automaticAmmoInventory.text = _player.CurrentAutomaticAmmo.ToString();
            _shotgunAmmoInventory.text = _player.CurrentShotgunAmmo.ToString();
        }
    }
}
