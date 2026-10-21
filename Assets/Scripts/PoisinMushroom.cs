using UnityEngine;

public class PoisonMushroom : MonoBehaviour
{
    public int pointsToLose = 2;

    [Header("Poison Sound")]
    public AudioClip poisonSound;
    [Range(0f, 1f)]
    public float soundVolume = 0.8f;

    private bool hasBeenEaten = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenEaten) return;

        if (other.GetComponent<PuduMovement>() != null)
        {
            // Play the poison sound at the mushroom's position
            if (poisonSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    poisonSound,
                    transform.position,
                    soundVolume
                );
            }

            ScoreManager scoreManager =
                FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.DecreaseScore(pointsToLose);
            }

            hasBeenEaten = true;
            Destroy(gameObject);
        }
    }
}
