using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int mushrooms = 0;
    public TextMeshProUGUI mushroomText;

    [Header("Level Complete")]
    public int mushroomsRequired = 10;
    public GameObject levelCompletePanel;

    private bool levelComplete = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(false);
        }

        UpdateText();
    }

    public void IncreaseScore()
    {
        if (levelComplete) return;

        mushrooms++;
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

        if (levelCompletePanel != null)
        {
            levelCompletePanel.SetActive(true);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
