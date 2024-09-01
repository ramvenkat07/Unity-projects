using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class AutoCreate : MonoBehaviour
{
    public Vector3 initialPosition;
    public GameObject blockPrefab;
    public float[] blocksZRef = new float[4];
    //GameObject[] blocks = new GameObject[20];
    const float distanceBetweenBlocks = 0.62f;
    float preserveSpeed;
    internal float relativeSpeed;
    int prevNum = 0;
    int randNum = 0;
    private void Awake()
    {
        //for (int i = 0; i < blocks.Length; i++)
        //{
        //    blocks[i] = Instantiate(blockPrefab,gameObject.transform);
        //}
        CreateBlocks();
    }

    private void OnEnable()
    {
        Time.timeScale = 1;
        relativeSpeed = 2f;
        
        //InvokeRepeating("CreateBlocks", 0, 0.1f);
    }
    private void FixedUpdate()
    {
        if (transform.childCount <= 20)
        {
            CreateBlocks();
        }
    }
    internal void Pause()
    {
        preserveSpeed = relativeSpeed;
        relativeSpeed = 0;
    }

    internal void Resume()
    {
        relativeSpeed = preserveSpeed;
    }

    void CreateBlocks()
    {

        for (int i = 0; i < 30; i++)
        {
            randNum = Random.Range(0, 4);
            while (prevNum == randNum)
            {
                randNum = Random.Range(0, 4);
            }
            prevNum = randNum;
            GameObject block = Instantiate(blockPrefab, transform);
            block.transform.localPosition = new Vector3(initialPosition.x - (distanceBetweenBlocks), initialPosition.y, blocksZRef[randNum]);
            initialPosition = block.transform.localPosition;
            block.name = $"block {i}";
        }


    }
    void Update()
    {
        
        transform.Translate(relativeSpeed * Time.deltaTime, 0, 0);
    }

    private void OnDisable()
    {

        CancelInvoke();
    }
}
