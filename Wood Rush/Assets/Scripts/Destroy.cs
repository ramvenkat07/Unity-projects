using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    bool isTouched;
    static float rateOfGlass = 0f;
    internal Vector3 velocity = Vector3.zero;
    GameObject child0;
    GameObject child1;
    int prevScore = 0;
    private void Start()
    {
        rateOfGlass = 2.0f;
        child0 = gameObject.transform.GetChild(0).gameObject;
        child1 = gameObject.transform.GetChild(1).gameObject;
    }

 
    void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                HandleTouch(touch.position);
            }
        }
        if (child1.transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
        //Debug.Log(gameObject.name + gameObject.transform.position.x);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.name == "Saviour")
        {
            Destroy(gameObject);
        }
    }
    public void HandleTouch(Vector2 touchPosition)
    {
        if (isTouched)
            return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == child0 && ScoreHandler.instance.IsActiveInHirearchy())
                    {
                        // Deactivate child0 and activate child1
                        child0.SetActive(false);
                        audioSource.Play();
                        child1.SetActive(true);
                        //VibrationController.Vibrate();
                        ScoreHandler.instance.AddScore(1);
                        return;
                    }
                }
               
            }
        }

    }
}


