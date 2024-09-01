using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneToMainScene : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(LoadMenuScene());
    }

    IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(3.6f);
        SceneManager.LoadSceneAsync(1);
        yield return null;
    }

}
