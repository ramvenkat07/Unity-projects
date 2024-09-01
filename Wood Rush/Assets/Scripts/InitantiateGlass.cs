
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitantiateGlass : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;
    [SerializeField]
    Vector3[] Lanes = new Vector3[4];
    float interval = 0.4f;
    int prevPos = 0;
    private void Start()
    {

        //InvokeRepeating("SpawnObject", 0.0f, interval);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void SpawnObject()
    {
        int lane = Random.Range(0, 4);
        Instantiate(objectToSpawn, Lanes[lane], Quaternion.identity, gameObject.transform);
        //while(prevPos == lane)
        //{
        //    lane = Random.Range(0, 4);
        //}
        //prevPos = lane;

    }

   
}
