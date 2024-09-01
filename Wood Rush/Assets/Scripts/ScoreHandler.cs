using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler instance;
     float scoreMultiplier;
    public TextMeshProUGUI scoreText;
    static int score;
    public AutoCreate autoCreate;

    public GameObject animationText;
    public GameObject gameOverGlass;
    public GameObject addPanel;

    public bool IsActiveInHirearchy()
    {
        if (!animationText.activeInHierarchy && !gameOverGlass.activeInHierarchy && !addPanel.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
        }
        score = 0;
        scoreMultiplier = 2f;  // Ensure this is reset correctly
        UpdateScoreText();
        Debug.Log($"Initial Score Multiplier: {scoreMultiplier}");
    }


    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        if (score != 0 && score % 20 == 0)
        {
            Debug.Log(scoreMultiplier);
            scoreMultiplier = scoreMultiplier + 0.2f;
            autoCreate.relativeSpeed = scoreMultiplier;
            
        }
    }

    internal int GetScore()
    {
        return score;
    }
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
   

}
