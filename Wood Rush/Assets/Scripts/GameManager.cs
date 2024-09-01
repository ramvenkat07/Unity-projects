using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverpanel;
    public GameObject addPanel;
    public GameObject CreateBlock;
    public GameObject pausePanel;
    public TextMeshProUGUI GameOverScore;
    public TextMeshProUGUI GameOverhighScore;
    public TextMeshProUGUI actualScore;
    public GameObject highScoreAnimation;
    public GameObject objectToPlace; // The object to be placed
    public Camera mainCamera; // Reference to the main camera
    public GameObject gmaeOverGlass;
    public GameObject AnimationText;
    [SerializeField]
    AudioSource gameOverAudio;
    public GameObject canvas;
    private int highScore = 0;
    static float  preserveSpeed;
    public GameObject Thor;
    AutoCreate autoCreate;
    private void Start()
    {
        autoCreate = CreateBlock.GetComponent<AutoCreate>();
        //preserveSpeed = 0;
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }

    public void Replay()
    {
        CancelInvoke();
        StopAllCoroutines();
        ResumeGame();
        SceneManager.LoadScene(1);
    }

    IEnumerator gameOverDisplay()
    {

        CreateBlock.SetActive(false);
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        gameoverpanel.SetActive(true);
        HandleGameOver();
        yield return null;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision != null && collision.transform.name == "Cube")
        {
            //StartCoroutine(OnGameOver());
            StartCoroutine(OnAddDisplay());

        }
    }


    public void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();

    }

    public void HandleGameOver()
    {
        int Score = int.Parse(actualScore.text);
        GameOverScore.text = Score.ToString();
        if (PlayerPrefs.GetInt("HighScore") != 0)
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        if (highScore <= Score)
        {
            highScoreAnimation.SetActive(true);
            SaveHighScore(Score);

        }
        GameOverhighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }



    // Add playing section ----------------------------------------------------------------------------------------------------

    IEnumerator OnAddDisplay()
    {
        
        //CreateBlock.GetComponent<AutoCreate>().relativeSpeed = 0;
        autoCreate.Pause();
        objectToPlace.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        objectToPlace.SetActive(false);
        addPanel.SetActive(true);
        yield return null;
    }


    public void ResumeFromAdd()
    {
       
        StartCoroutine(IresumeFromAdd());
    }

    IEnumerator IresumeFromAdd()
    {
        //PauseGame();
        //CreateBlock.GetComponent<AutoCreate>().relativeSpeed = preserveSpeed;
        autoCreate.Resume();
        Debug.Log("From gamemanager" +preserveSpeed);
        Thor.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        Thor.SetActive(true);
        yield return null ;
    }

    //---------------------------------------------------------------------------------------------------------------------------

    public void OnGameOver()
    {
        StartCoroutine(IonGameOver());
    }
    IEnumerator IonGameOver()
    {
        CreateBlock.GetComponent<AutoCreate>().relativeSpeed = 0;
        gameOverAudio.Play();
        //objectToPlace.SetActive(true);
        //yield return new WaitForSeconds(2);
        StartCoroutine(gameOverDisplay());
        //objectToPlace.SetActive(false);
        yield return null;
    }


    private void Update()
    {
        
       // Debug.Log(preserveSpeed);
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "Cube" && !addPanel.activeInHierarchy &&!pausePanel.activeInHierarchy && !AnimationText.activeInHierarchy)
                    {
                        //preserveSpeed = CreateBlock.GetComponent<AutoCreate>().relativeSpeed;
                        Debug.Log("CUbe collider");
                    }
                }

                else
                {
                    if (CreateBlock.activeInHierarchy && !pausePanel.activeInHierarchy && !AnimationText.activeInHierarchy && !addPanel.activeInHierarchy && !objectToPlace.activeInHierarchy && !gmaeOverGlass.activeInHierarchy)
                    {
                        // StartCoroutine(OnGameOver());
                        //preserveSpeed = CreateBlock.GetComponent<AutoCreate>().relativeSpeed;
                        StartCoroutine(OnAddDisplay());
                        return;
                    }

                    return;
                }

            }
        }
    }

}
