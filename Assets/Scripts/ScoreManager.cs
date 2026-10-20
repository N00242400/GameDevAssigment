
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int mushrooms = 0;
    public TextMeshProUGUI mushroomText;

    void Start()
    {
        UpdateText();
    }

    public void IncreaseScore()
    {
        mushrooms++;
        UpdateText();
    }

    void UpdateText()
    {
        if (mushroomText != null)
        {
            mushroomText.text = "Mushrooms Eaten: " + mushrooms;
        }
    }
}
