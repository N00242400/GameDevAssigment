using UnityEngine;
using System.Collections;

public class TeleportPad : MonoBehaviour
{
    public Transform destination;

    private static bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || isTeleporting)
            return;

        StartCoroutine(TeleportPlayer(other));
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        isTeleporting = true;

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        player.transform.position =
            destination.position + Vector3.up * 1.5f;

        if (controller != null)
            controller.enabled = true;

        // Allow time to leave the destination pad
        yield return new WaitForSeconds(3f);

        isTeleporting = false;
    }
}
