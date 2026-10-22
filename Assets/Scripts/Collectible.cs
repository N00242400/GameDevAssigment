using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;
    private bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (collected)
            return;

        collected = true;

        ScoreManager scoreManager =
            FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.IncreaseScore();
        }

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();

            Collider mushroomCollider =
                GetComponent<Collider>();

            if (mushroomCollider != null)
                mushroomCollider.enabled = false;

            Renderer[] renderers =
                GetComponentsInChildren<Renderer>();

            foreach (Renderer r in renderers)
            {
                r.enabled = false;
            }

            Destroy(gameObject, audioSource.clip.length);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
