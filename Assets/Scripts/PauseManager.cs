using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanelPrefab;

    private static bool gameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausePanelPrefab.SetActive(!_pausePanelPrefab.gameObject.activeSelf);

            gameIsPaused = !gameIsPaused;
            PauseTheGame();
        }

        GoMainMenuOrQuitGame();
        QuitGame();
    }

    void PauseTheGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
    }

    void GoMainMenuOrQuitGame()
    {
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                gameIsPaused = !gameIsPaused;
                SceneManager.LoadScene("Main_Menu"); // Return to Main Menu
            }
        }
    }

    void QuitGame()
    {
        if(Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
}
