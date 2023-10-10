using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public Player player;

    // Update is called once per frame
    void Update()
    {
        // Checks if player is null
        if (player)
        {
            transform.position = new Vector3(0, player.transform.position.y + 3, -1);
        }
    }
}
