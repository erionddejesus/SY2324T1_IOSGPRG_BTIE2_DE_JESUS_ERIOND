using UnityEngine;

public class AutomaticAmmo : Ammo
{
    protected override void IncreaseAmmo(PlayerController player)
    {
        if (player.CurrentAutomaticAmmo < player.MaxAutomaticAmmo)
        {
            player.CurrentAutomaticAmmo += Random.Range(5, 16);
            player.CurrentAutomaticAmmo = Mathf.Clamp(player.CurrentAutomaticAmmo, 0, player.MaxAutomaticAmmo);
        }
    }
}
