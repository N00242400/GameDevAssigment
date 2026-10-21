using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int mushrooms = 0;
    public TextMeshProUGUI mushroomText;

    [Header("Eating Sound")]
    public AudioClip mushroomEatSound;
    private AudioSource audioSource;

    [Header("Level Complete")]
    public int mushroomsRequired = 10;
    public GameObject levelCompletePanel;
    public GameObject mushroomCounter;

    private bool levelComplete = false;

    void Start()
    {
        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);
        }

        if (mushroomCounter != null)
        {
            mushroomCounter.SetActive(true);
        }

        UpdateText();
    }

    public void IncreaseScore()
    {
        if (levelComplete) return;

        mushrooms++;

        if (mushroomEatSound != null)
        {
            audioSource.PlayOneShot(mushroomEatSound);
        }

        UpdateText();

        if (mushrooms >= mushroomsRequired)
        {
            ShowLevelComplete();
        }
    }

    public void DecreaseScore(int amount)
    {
        if (levelComplete) return;

        mushrooms -= amount;
        UpdateText();
    }

    void UpdateText()
    {
        if (mushroomText != null)
        {
            mushroomText.text = "Mushrooms Eaten: "
                + mushrooms + " / " + mushroomsRequired;
        }
    }

    void ShowLevelComplete()
    {
        levelComplete = true;

        if (mushroomCounter != null)
        {
            mushroomCounter.SetActive(false);
        }

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
