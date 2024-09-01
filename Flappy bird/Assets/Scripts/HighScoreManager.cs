using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    
    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }

    public void LoadHighScore(int highScore)
    {
        gameObject.SetActive(true);
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = highScore.ToString();
    }

}
