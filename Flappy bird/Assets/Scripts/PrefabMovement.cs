using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMovement : MonoBehaviour, SpeedInterface
{
    [SerializeField]
    float speed;
    ObstaclesInstantiation obstacleInstantiation;
    private void Start()
    {
        obstacleInstantiation = gameObject.transform.parent.transform.GetComponent<ObstaclesInstantiation>();
        speed = 10f;
        StartCoroutine(InitiateCoin());

    }
    IEnumerator InitiateCoin()
    {

        yield return new WaitForSeconds(Random.Range(1, 6));
        int rand = Random.Range(0, 2);
        if (gameObject.transform.position.x >= -6)
        {
            gameObject.transform.GetChild(rand).gameObject.SetActive(true);
        }
    }
    void SpeedInterface.ChangeSpeed()
    {

    }
    void Update()
    {
        int time = (int)Time.realtimeSinceStartup;
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x <= -25)
        {
            Destroy(gameObject);
        }
        gameObject.transform.GetChild(0).transform.Rotate(0, 5, 0);
        gameObject.transform.GetChild(1).transform.Rotate(0, 5, 0);
    }
}
