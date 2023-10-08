using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 4, -1);
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is null
        if (player)
        {
            transform.position = new Vector3(0, player.position.y + offset.y, offset.z);
        }
    }
}
