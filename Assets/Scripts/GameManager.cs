using UnityEngine;
using LootLocker.Requests;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private InstantiatePlayer _currentSpawner;
    public const int MAX_LIVES = 5;
    private int _currentLives = 5;
    private int _currentLevel = 1;
    private int _score;
    public event Action<int> LivesChanged;
    public event Action<int> LevelChanged;
    public event Action<int> ScoreChanged;
    public int Score { get => _score; }
    public int CurrentLives { get => _currentLives; }
    public int Level { get => _currentLevel; }
    public static GameManager Instance
    {
        get => _instance;
        set
        {
            if (_instance != null)
            {
                Destroy(value);
            }
            else
            {
                _instance = value;
                DontDestroyOnLoad(value.gameObject);
            }
        }
    }
    private void Awake()
    {
        GameManager.Instance = this;
    }
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }
    public void KillPlayer()
    {
        _currentLives--;
        if (_currentLives >= 0)
        {
            _currentSpawner.InstantiatePlayerOnLevel();
            LivesChanged?.Invoke(_currentLives);
        }
        else
        {
            Debug.Log("GameOver");
            Application.Quit();
        }
    }
    public void AttachSpawner(InstantiatePlayer spawner)
    {
        _currentSpawner = spawner;
    }
    public void CompleteLevel()
    {
        //TODO process score
        _score += ScoreCalculator.CalculateScore(_currentLevel, MAX_LIVES - CurrentLives, 0, 0);
        ScoreChanged?.Invoke(_score);
        _currentLives = MAX_LIVES;
        _currentLevel++;
        LevelChanged?.Invoke(_currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
