using UnityEngine;

public class miniMap : MonoBehaviour
{
    public float heightAbovePlayer = 20f;
    public Transform player;

    private void LateUpdate()
    {
        if (player == null) return;

        transform.position = new Vector3(
            player.position.x,
            player.position.y + heightAbovePlayer,
            player.position.z
        );
    }
}
