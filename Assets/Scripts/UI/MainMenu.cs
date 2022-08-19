using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Gamestart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
