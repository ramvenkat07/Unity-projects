using UnityEngine;
using UnityEngine.Animations;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of the plane's movement
    public float rotationSpeed = 50f; // Speed of the plane's rotation

    private Rigidbody2D rb;
    float input;
    // Handle touch input
    float horizontalInput = 0f;
    void Start()
    {
        // Get the Rigidbody2D component attached to the plane
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update()
    //{
    //    input = Input.GetAxis("Horizontal");


    //}

    void Update()
    {



        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Determine if the touch is on the left or right half of the screen
            if (touch.position.x < Screen.width / 2)
            {
                horizontalInput = -1f; // Left half of the screen
            }
            else if (touch.position.x >= Screen.width / 2)
            {
                horizontalInput = 1f; // Right half of the screen
            }
        }

        else
        {

            horizontalInput = 0f;
        }



    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed * Time.deltaTime * 10;
        rb.angularVelocity = -horizontalInput * rotationSpeed;
    }

}
