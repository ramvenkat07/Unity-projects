using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class OnGameOver : MonoBehaviour
{
    [SerializeReference]
    GameObject gameOvertxt;
    [SerializeReference]
    GameObject restart;
    [SerializeReference]
    Volume volume;

    private void Start()
    {
        volume = GetComponent<Volume>();
    }
    public void GameOver()
    {

        volume.enabled = true;
        gameOvertxt.SetActive(true);
        restart.SetActive(true);

    }

    public void OnReset()
    {
        SceneManager.LoadScene(0);
    }

}
