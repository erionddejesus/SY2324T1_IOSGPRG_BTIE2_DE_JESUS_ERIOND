using UnityEngine;

public class PistolAmmo : Ammo
{
    protected override void IncreaseAmmo(PlayerController player)
    {
        if (player.CurrentPistolAmmo < player.MaxPistolAmmo)
        {
            player.CurrentPistolAmmo += Random.Range(1, 9);
            player.CurrentPistolAmmo = Mathf.Clamp(player.CurrentPistolAmmo, 0, player.MaxPistolAmmo);
        }
    }
}
