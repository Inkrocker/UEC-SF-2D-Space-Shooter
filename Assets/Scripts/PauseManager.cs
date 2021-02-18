using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanelPrefab;

    public static bool gameIsPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausePanelPrefab.SetActive(!_pausePanelPrefab.gameObject.activeSelf);

            gameIsPaused = !gameIsPaused;

            PauseTheGame();
            ReturnToMainMenu();
            QuitGame();
        }
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

    void ReturnToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0); // Return to Main Menu
        }
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
