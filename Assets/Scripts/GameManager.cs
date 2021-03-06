using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    [SerializeField]
    private GameObject _restartLevelButton;

    private void Update()
    {
        if (_isGameOver == true)
        {
            _restartLevelButton.SetActive(true);
        }
    }

    public void OnClickRestart(string game)
    {
        SceneManager.LoadScene(game); //Current Game Scene
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
