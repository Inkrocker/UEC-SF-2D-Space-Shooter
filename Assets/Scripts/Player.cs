using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager _uiManager;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    private float _fireRate = 0.2f;

    private float _tripleFireFate = 0.05f;

    private float _canFire = -1.0f;

    private int _lives = 3;

    private int _score;

    private float _speed = 5;

    private SpawnManager _spawnManager;

    public bool isTripleShotActive = false;

    public bool isSpeedBoostActive = false;

    public bool isShieldsActive = false;

    [SerializeField]
    private GameObject _shieldVisualizerPrefab;

    [SerializeField]
    private GameObject _burnDmg01Prefab;

    [SerializeField]
    private GameObject _burnDmg02Prefab;

    [SerializeField]
    private GameObject _playerExplosionPrefab;

    [SerializeField]
    private SpriteRenderer _playerFlashColor;

    [SerializeField]
    private Animator _playerAnim;

    [SerializeField]
    private AudioClip _laserSoundClip;

    [SerializeField]
    private AudioSource _audioSource;

    private void Start()
    {
        transform.position = new Vector3(-6.0f, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        _audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL!");
        }

        if (_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL!");
        }

        _playerAnim = GetComponent<Animator>();

        if(_playerAnim == null)
        {
            Debug.LogError("The Player Animator is NULL!");
        }

       if(_audioSource == null)
       {
           Debug.LogError("The Audio Source on the Player is NULL!");
       }
       
       else
       {
           _audioSource.clip = _laserSoundClip;
       }
    }

    private void Update()
    {
        PlayerMovement();

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            LaserShot();
        }

        PlayerAnimUp();
        PlayerAnimDown();
    }

    void PlayerAnimUp()
    {
        if(Input.GetKeyDown(KeyCode.W))
        _playerAnim.SetTrigger("PlayerUp");

        else if (Input.GetKeyUp(KeyCode.W))
        {
            _playerAnim.SetTrigger("PlayerIdle");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _playerAnim.SetTrigger("PlayerUp");
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _playerAnim.SetTrigger("PlayerIdle");
        }
    }

    void PlayerAnimDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerAnim.SetTrigger("PlayerDown");
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            _playerAnim.SetTrigger("PlayerIdle");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _playerAnim.SetTrigger("PlayerDown");
        }

        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _playerAnim.SetTrigger("PlayerIdle");
        }
    }

    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveHorizontal, moveVertical, 0) * _speed * Time.deltaTime);

        if (transform.position.y >= 5.2f)
        {
            transform.position = new Vector3(transform.position.x, 5.2f, 0.0f);
        }

        else if (transform.position.y <= -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0.0f);
        }

        if (transform.position.x >= 8.25f)
        {
            transform.position = new Vector3(8.25f, transform.position.y, 0.0f);
        }

        else if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, 0.0f);
        }
    }

    void LaserShot()
    {
        var laserOffset = new Vector3(1.348f, -0.282f, 0.0f);

        if (isTripleShotActive == true)
        {
            _canFire = Time.time + _tripleFireFate;
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        
        else
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + laserOffset, Quaternion.identity);
        }

        _audioSource.Play();
    }

    public void Damage()
    {
        if (isShieldsActive == true)
        {
            isShieldsActive = false;
            _shieldVisualizerPrefab.SetActive(false);
            return;
        }

        _lives -= 1;
        StartCoroutine(PlayerFlashDamage());

        _uiManager.UpdateLifeArray(_lives);
        BurnDamage();

        if (_lives < 1)
        {
            Vector3 SpawnPlayerExplosion = new Vector3(transform.position.x, transform.position.y, 0.0f);
            Instantiate(_playerExplosionPrefab, SpawnPlayerExplosion, Quaternion.identity);
            _speed = 0;
            Destroy(this.gameObject, 0.3f);
            _spawnManager.PlayerDead();
            _uiManager.GameOverSequence();
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    public void SpeedPowerUpActive()
    {
        if (isSpeedBoostActive != true)
        {
            isSpeedBoostActive = true;
            _speed = 10;
            StartCoroutine(SpeedBoostPowerDownRoutine());
        }
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
        _speed = 5;
    }

    public void ShieldsActive()
    {
        isShieldsActive = true;
        _shieldVisualizerPrefab.SetActive(true);
    }

    public void BurnDamage()
    {
        if(_lives == 2)
        {
            _burnDmg01Prefab.SetActive(true);

            PlayerAnimUp();
            PlayerAnimDown();
        }

        else if(_lives == 1)
        {
            _burnDmg01Prefab.SetActive(true);
            _burnDmg02Prefab.SetActive(true);

            PlayerAnimUp();
            PlayerAnimDown();
        }
    }

    IEnumerator PlayerFlashDamage()
    {
        _playerFlashColor.color = Color.red;
        yield return new WaitForSeconds(0.115f);
        _playerFlashColor.color = Color.white;
    }

    public void AddToScore(int points)
    {
        _score += points;
        _uiManager.UpdatePlayerScore(_score);
    }
}
