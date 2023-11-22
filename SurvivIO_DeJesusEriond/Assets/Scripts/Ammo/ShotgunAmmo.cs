using UnityEngine;

public class ShotgunAmmo : Ammo
{
    protected override void IncreaseAmmo(PlayerController player)
    {
        if (player.CurrentShotgunAmmo < player.MaxShotgunAmmo)
        {
            player.CurrentShotgunAmmo += Random.Range(1, 3);
            player.CurrentShotgunAmmo = Mathf.Clamp(player.CurrentShotgunAmmo, 0, player.MaxShotgunAmmo);
        }
    }
}
