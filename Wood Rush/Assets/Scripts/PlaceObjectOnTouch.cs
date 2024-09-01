using UnityEngine;

public class PlaceObjectOnTouch : MonoBehaviour
{
    public GameObject objectToPlace; // The object to be placed
    public Camera mainCamera; // Reference to the main camera

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Convert touch position to world position
                //Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.nearClipPlane));

                // Adjust z position (as ScreenToWorldPoint uses the camera's near clip plane)
                //touchPosition.z = 0;

                // Instantiate or move the object to the touch position
                Instantiate(objectToPlace, new Vector3(1, -0.981999993f, -0.0700000003f), Quaternion.identity);
            }
        }
    }
}
