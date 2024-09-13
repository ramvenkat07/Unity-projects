using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField]
    Transform plane;
    [SerializeField]
    GameObject particles;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("CreateParticles", 0, 0.1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = transform.up * 4.1f;
        Vector2 direction = (Vector2)plane.position - rb.position;
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotation * 200;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Plane")
            transform.GetChild(0).gameObject.SetActive(true);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(destroyMissile());

    }

    void CreateParticles()
    {
        GameObject smoke = Instantiate(particles,transform.position,Quaternion.identity);
        smoke.transform.position = transform.position;
        smoke.transform.localRotation = Quaternion.identity;
    }

    IEnumerator destroyMissile()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

    
}
