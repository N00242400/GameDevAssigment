using UnityEngine;
using System.Collections;

public class TeleportPad : MonoBehaviour
{
    public Transform destination;

    [Header("Teleport Sound")]
    public AudioClip swooshSound;

    [Range(0f, 1f)]
    public float soundVolume = 1f;

    private AudioSource audioSource;
    private static bool isTeleporting = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
        audioSource.volume = soundVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Teleport pad touched by: " +
            other.name + " | Tag: " + other.tag);

        if (!other.CompareTag("Player") || isTeleporting)
            return;

        if (destination == null)
        {
            Debug.LogError("Teleport destination is not assigned!", this);
            return;
        }

        StartCoroutine(TeleportPlayer(other));
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        isTeleporting = true;

        if (swooshSound != null)
        {
            audioSource.PlayOneShot(swooshSound, soundVolume);
            Debug.Log("Playing teleport swoosh.");
        }
        else
        {
            Debug.LogWarning("Swoosh sound is not assigned!");
        }

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        player.transform.position =
            destination.position + Vector3.up * 1.5f;

        if (controller != null)
            controller.enabled = true;

        yield return new WaitForSeconds(3f);

        isTeleporting = false;
    }
}
