using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : HUD
{
    [SerializeField] Canvas _canvas;

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

    public IEnumerator CO_ShowHealthBar()
    {
        _canvas.enabled = true;
        yield return new WaitForSeconds(1.0f);
        _canvas.enabled = false;
    }
}
