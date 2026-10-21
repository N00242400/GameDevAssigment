using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;

    public void ShowInstructions()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("level_1");
    }
}
