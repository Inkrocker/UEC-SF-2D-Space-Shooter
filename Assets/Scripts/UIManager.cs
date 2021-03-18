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
    private Sprite[] _bloomBombSprites;
    [SerializeField]
    private Image _bloomBombsImage;

    [SerializeField]
    private GameObject _doubleShotHUDPrefab;

    [SerializeField]
    private GameObject _doubleShotOffHUDPrefab;

    [SerializeField]
    private GameObject _tripleShotHUDPrefab;

    [SerializeField]
    private GameObject _tripleShotOffHUDPrefab;

    [SerializeField]
    private GameObject _speedBoostHUDPrefab;

    [SerializeField]
    private GameObject _speedboostOffHUDPrefab;

    [SerializeField]
    private GameObject _shieldsHUDPrefab;

    [SerializeField]
    private GameObject _shieldsOffHUDPrefab;

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
        if(_gameManager == null)
        {
            Debug.LogError("The Game Manager is NULL!");
        }
        
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }
    }

    private void Update()
    {
        DoubleShotHUDActive();
        TripleShotHUDActive();
        SpeedBoostHUDActive();
        ShieldsHUDActive();
    }

//----------- SCORE / LIVES / BLOOM BOMBS HUD ICONS UPDATE ----------------
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

    public void UpdateBloomBombsArray(int currentBloomBombs)
    {
        _bloomBombsImage.sprite = _bloomBombSprites[currentBloomBombs];

        if(Input.GetKeyDown(KeyCode.B) && currentBloomBombs < 1)
        {
            currentBloomBombs = 0;
            Debug.Log("BLOOM BOMBS DEPLETED");
        }
    }

//----------- POWER-UPS HUD ICONS UPDATE ----------------
    private void DoubleShotHUDActive()
    {
        if (_player.isDoubleShotActive == true)
        {
            _doubleShotHUDPrefab.SetActive(true);
            _doubleShotOffHUDPrefab.SetActive(false);
        }

        else if (_player.isDoubleShotActive != true)
        {
            _doubleShotHUDPrefab.SetActive(false);
            _doubleShotOffHUDPrefab.SetActive(true);
        }
    }

    private void TripleShotHUDActive()
    {
        if (_player.isTripleShotActive == true)
        {
            _tripleShotHUDPrefab.SetActive(true);
            _tripleShotOffHUDPrefab.SetActive(false);
        }

        else if (_player.isTripleShotActive != true)
        {
            _tripleShotHUDPrefab.SetActive(false);
            _tripleShotOffHUDPrefab.SetActive(true);
        }
    }

    private void SpeedBoostHUDActive()
    {
        if(_player.isSpeedBoostActive == true)
        {
            _speedBoostHUDPrefab.SetActive(true);
            _speedboostOffHUDPrefab.SetActive(false);
        }

        else if (_player.isSpeedBoostActive != true)
        {
            _speedBoostHUDPrefab.SetActive(false);
            _speedboostOffHUDPrefab.SetActive(true);
        }
    }

   public void ShieldsHUDActive()
   {
       if (_player.isShieldsActive == true)
       {
           _shieldsHUDPrefab.SetActive(true);
            _shieldsOffHUDPrefab.SetActive(false);
       }
   
       else if(_player.isShieldsActive != true)
        {
            _shieldsHUDPrefab.SetActive(false);
            _shieldsOffHUDPrefab.SetActive(true);
        }
   }

//----------- IN-GAME "GAME OVER" TEXT ----------------
//----------- APPEARS UPON PLAYER DEATH ---------------
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