using UnityEngine;

public class PoisonMushroom : MonoBehaviour
{
    public int pointsToLose = 2;

    private bool hasBeenEaten = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenEaten) return;

        if (other.GetComponent<PuduMovement>() != null)
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.DecreaseScore(pointsToLose);
            }

            hasBeenEaten = true;
            Destroy(gameObject);
        }
    }
}
