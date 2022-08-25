using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject endGameMenu;
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        endGameMenu.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Game Closed");
        endGameMenu.SetActive(false);
        Application.Quit();
    }
}
