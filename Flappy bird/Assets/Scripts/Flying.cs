using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flying : MonoBehaviour
{

    Rigidbody2D bird;
    [SerializeField]
    TextMeshProUGUI score;
    [SerializeField]
    GameObject scoreDisplay;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    AudioHandler audioHandler;
    [SerializeField]
    OnGameOver onGameOver;
    [SerializeField]
    HighScoreManager highScoreManager;
    bool isGameOver = false;

    void Start()
    {
        bird = transform.GetComponent<Rigidbody2D>();
        score.text = 0.ToString();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            bird.velocity = Vector2.up * 10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(audioHandler != null)
        {
            audioHandler.playGameOverAudioSource();
        }
        score.gameObject.SetActive(false);
        onGameOver.GameOver();
        isGameOver = true;
        if(int.Parse(score.text) > PlayerPrefs.GetInt("HighScore"))
        {
            highScoreManager.SaveHighScore(int.Parse(score.text));
        }
        scoreDisplay.SetActive(true);
        scoreDisplay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = score.text;
        highScoreManager.LoadHighScore(PlayerPrefs.GetInt("HighScore"));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "coin")
        {
            collision.gameObject.SetActive(false);
            if (audioHandler != null) 
            {
                audioHandler.playCoinAudioSource();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        score.text = (int.Parse(score.text) + 1).ToString();
    }

}
