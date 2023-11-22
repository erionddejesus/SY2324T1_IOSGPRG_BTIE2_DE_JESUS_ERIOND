using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : HUD
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        transform.rotation = _camera.transform.rotation;

        base.UpdateHealthBar();
    }
}
