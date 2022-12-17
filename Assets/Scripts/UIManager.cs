using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
  
    private void Awake()
    {
 
    }
    private void Start()
    {
        OnSetLevel(GameManager.Instance.Level);
        OnSetScore(GameManager.Instance.Score);
        OnSetLives(GameManager.Instance.CurrentLives);
        GameManager.Instance.LevelChanged += OnSetLevel;
        GameManager.Instance.LivesChanged += OnSetLives;
        GameManager.Instance.ScoreChanged += OnSetLives;
    }
    private void OnDestroy()
    {
        GameManager.Instance.LevelChanged -= OnSetLevel;
        GameManager.Instance.LivesChanged -= OnSetLives;
        GameManager.Instance.ScoreChanged -= OnSetLives;
    }



    public void OnSetLevel(int level)
    {
        levelText.SetText ( "Level: " + level);
    }
    public void OnSetLives(int lives)
    {
        livesText.SetText( "Lives: " + lives);

    }
    public void OnSetScore(int score)
    {
        scoreText.SetText( "Score: " + score);
    }
}
