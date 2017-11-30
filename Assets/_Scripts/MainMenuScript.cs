using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        if (GameManager.instance != null)
            Destroy(GameManager.instance.gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
