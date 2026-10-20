using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadLevel2()
    {
        SceneManager.LoadScene("level_2");
    }
}
