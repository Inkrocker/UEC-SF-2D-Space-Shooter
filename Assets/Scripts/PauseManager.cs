using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _inGameOptions;

    private void Update()
    {
        QuitGame();
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeTheGame()
    {
            Time.timeScale = 1;
    }

    public void GoMainMenu(string Main_Menu)
    {
        SceneManager.LoadScene(Main_Menu); // Return to Main Menu
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
