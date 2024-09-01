using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CalculateFPS : MonoBehaviour
{

    public TextMeshProUGUI fpsText;
    void Start()
    {
        Application.targetFrameRate = 90; // Set this to your target frame rate
    }

    void Update()
    {
       fpsText.text =  (1.0f / Time.deltaTime).ToString();
    }
}



