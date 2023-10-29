using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ThingsSpeakApi : MonoBehaviour
{

    public string apiKey = "YOUR_API_WRITE_KEY";
    internal static string url = "https://api.thingspeak.com/update?api_key=8GMXKFYIAGJINKUD&field1=0";
    private void Start()
    {
        FindObjectOfType<Button>().apiCall = this;
    }
    public void SendDataToThingSpeak()
    {
       
        StartCoroutine(SendRequest(url));
    }

    IEnumerator SendRequest(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, ""))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Data sent to ThingSpeak successfully.");
            }
        }
    }
}
