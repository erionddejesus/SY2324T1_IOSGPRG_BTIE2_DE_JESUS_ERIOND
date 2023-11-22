using TMPro;
using UnityEngine;

public class PlayerHUD : HUD
{
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;

    [SerializeField] private TextMeshProUGUI[] _weaponSlots;
    [SerializeField] private TextMeshProUGUI[] _ammoInventory;
    [SerializeField] private TextMeshProUGUI[] _ammoCurrent;

    private void Update()
    {
        base.UpdateHealthBar();

        UpdateWeaponText();
        UpdateAmmoText();
        UpdateCurrentAmmoText();
    }

    public void UpdateWeaponText()
    {
        for (int i = 0; i < 2; i++)
        {
            TextMeshProUGUI inventory = _weaponSlots[i];

            inventory.text = (i + 1).ToString() + "\n" + _inventory.GetWeaponName((WeaponSlot)i);
        }
    }

    public void UpdateAmmoText()
    {
        for (int i = 0; i < 3; i++)
        {
            TextMeshProUGUI inventory = _ammoInventory[i];

            inventory.text = _inventory.GetCurrentAmmo((AmmoType)i).ToString();
        }
    }

    public void UpdateCurrentAmmoText()
    {
        if (_player.CurrentAmmoType == AmmoType.None)
        {
            return;
        }

        _ammoCurrent[0].text = _player.CurrentClip.ToString();
        _ammoCurrent[1].text = _inventory.GetCurrentAmmo(_player.CurrentAmmoType).ToString();
    }
}
