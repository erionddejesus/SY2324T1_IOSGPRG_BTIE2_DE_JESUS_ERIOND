using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : HUD
{
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;

    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private TextMeshProUGUI _enemiesLeft;

    [SerializeField] private Image _primarySlot;
    [SerializeField] private Image _secondarySlot;

    [SerializeField] private TextMeshProUGUI[] _weaponSlots;
    [SerializeField] private TextMeshProUGUI[] _ammoInventory;
    [SerializeField] private TextMeshProUGUI[] _ammoCurrent;

    private void Update()
    {
        base.UpdateHealthBar();

        UpdateEnemiesLeftText();
        UpdateWeaponSlotsColor();
        UpdateWeaponSlotsText();
        UpdateAmmoText();
        UpdateCurrentAmmoText();
    }

    private void UpdateEnemiesLeftText()
    {
        _enemiesLeft.text = _enemySpawner._enemies.Count.ToString();
    }

    private void UpdateWeaponSlotsColor()
    {
        if (_player.CurrentGunType == GunType.Pistol)
        {
            _primarySlot.color = new Color(1, 1, 1, 0.2f);
            _secondarySlot.color = new Color(0, 0, 0, 0.5f);
        }
        else
        {
            _primarySlot.color = new Color(0, 0, 0, 0.5f);
            _secondarySlot.color = new Color(1, 1, 1, 0.2f);
        }
    }

    private void UpdateWeaponSlotsText()
    {
        for (int i = 0; i < 2; i++)
        {
            TextMeshProUGUI inventory = _weaponSlots[i];

            inventory.text = (i + 1).ToString() + "\n" + _inventory.GetWeaponName((WeaponSlot)i);
        }
    }

    private void UpdateAmmoText()
    {
        for (int i = 0; i < _ammoInventory.Length; i++)
        {
            TextMeshProUGUI inventory = _ammoInventory[i];

            inventory.text = _inventory.GetCurrentAmmo((GunType)i).ToString();
        }
    }

    private void UpdateCurrentAmmoText()
    {
        if (_player.CurrentGunType == GunType.None)
        {
            return;
        }

        _ammoCurrent[0].text = _player.CurrentClip.ToString();
        _ammoCurrent[1].text = _inventory.GetCurrentAmmo(_player.CurrentGunType).ToString();
    }
}
