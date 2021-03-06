using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Sprite[] _livesSprites;

    [SerializeField]
    private Image _livesImage;

    [SerializeField]
    private GameObject _tripleShotHUDPrefab;

    [SerializeField]
    private GameObject _speedBoostHUDPrefab;

    [SerializeField]
    private GameObject _shieldsHUDPrefab;

    [SerializeField]
    private Text gameOverText, gameOverText2, gameOverText3;

    [SerializeField]
    private GameObject restartLevelButton;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private GameObject _pauseButton;

    private Player _player;

    private void Start()
    {
        _scoreText.text = "" + 0;
        gameOverText.gameObject.SetActive(false);
        restartLevelButton.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();

        if(_gameManager == null)
        {
            Debug.LogError("The Game Manager is NULL!");
        }

        if(_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }
    }

    private void Update()
    {
        TripleShotHUDActive();
        SpeedBoostHUDActive();
        ShieldsHUDActive();
    }
        
    /*private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }
    }*/

    public void UpdatePlayerScore(int playerScore)
    {
        _scoreText.text = "" + playerScore.ToString();
    }

    public void UpdateLifeArray(int currentLives)
    {
        _livesImage.sprite = _livesSprites[currentLives];

        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    private void TripleShotHUDActive()
    {
        if (_player.isTripleShotActive == true)
        {
            _tripleShotHUDPrefab.SetActive(true);
        }

        else if (_player.isTripleShotActive != true)
        {
            _tripleShotHUDPrefab.SetActive(false);
        }
    }

    private void SpeedBoostHUDActive()
    {
        if(_player.isSpeedBoostActive == true)
        {
            _speedBoostHUDPrefab.SetActive(true);
        }

        else if (_player.isSpeedBoostActive != true)
        {
            _speedBoostHUDPrefab.SetActive(false);
        }
    }

   public void ShieldsHUDActive()
   {
       if (_player.isShieldsActive == true)
       {
           _shieldsHUDPrefab.SetActive(true);
       }
   
       else if(_player.isShieldsActive != true)
        {
            _shieldsHUDPrefab.SetActive(false);
        }
   }

    public void GameOverSequence()
    {
        _gameManager.GameOver();
        gameOverText.gameObject.SetActive(true);
        gameOverText2.gameObject.SetActive(true);
        gameOverText3.gameObject.SetActive(true);
        StartCoroutine(BlinkingGameOverText());
        restartLevelButton.gameObject.SetActive(true);
    }
    
    IEnumerator BlinkingGameOverText()
    {
        while (true)
        {
            gameOverText3.text = "";
            gameOverText2.text = "";
            gameOverText.text = "game over";
            yield return new WaitForSeconds(0.15f);
            gameOverText3.text = "";
            gameOverText2.text = "game over";
            gameOverText.text = "";
            yield return new WaitForSeconds(0.15f);
            gameOverText3.text = "game over";
            gameOverText2.text = "";
            gameOverText.text = "";
            yield return new WaitForSeconds(0.15f);
            gameOverText3.text = "";
            gameOverText2.text = "game over";
            gameOverText.text = "";
            yield return new WaitForSeconds(0.15f);

        }
    }
}