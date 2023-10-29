using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;
public class Button : MonoBehaviour
{
    bool buttonClicked;
    internal ThingsSpeakApi apiCall;
    [SerializeField]
    GameObject directionalLight;
    [SerializeField]
    Volume globalVolume;
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.name == "Sphere")
                {
                    buttonClicked = !buttonClicked;
                   

                }
            }
        }
        ButtonMovement();
        //DirectionalLightMovement();
       // GloblaVolumeController();
    }

    void ButtonMovement()
    {

        if (gameObject.transform.position.x < 0.5 && buttonClicked)
        {
            gameObject.transform.Translate((1.2f+ gameObject.transform.position.x) * Time.deltaTime, 0, 0);
            ThingsSpeakApi.url = "https://api.thingspeak.com/update?api_key=8GMXKFYIAGJINKUD&field1=100";
            apiCall.SendDataToThingSpeak();
        }
        else if (gameObject.transform.position.x > 0 && !buttonClicked)
        {
            gameObject.transform.Translate(-(1.2f + gameObject.transform.position.x) * Time.deltaTime, 0, 0);
            ThingsSpeakApi.url = "https://api.thingspeak.com/update?api_key=8GMXKFYIAGJINKUD&field1=0";
            apiCall.SendDataToThingSpeak();
        }
    }

    //void DirectionalLightMovement()
    //{
    //    Debug.Log(directionalLight.transform.rotation.x);
    //    if (directionalLight.transform.rotation.x < 0.75f && buttonClicked)
    //    {
    //        directionalLight.transform.Rotate(0.8f, 0, 0);
    //    }
    //    else if (directionalLight.transform.rotation.eulerAngles.x > 1 && !buttonClicked)
    //    {
    //        directionalLight.transform.Rotate(-0.8f, 0, 0);
    //    }
    //}


}
