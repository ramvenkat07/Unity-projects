using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectToFollow;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero; // Velocity parameter needed for SmoothDamp
    [SerializeField]
    private float smoothTime = 1; // Adjust this value to change the smoothness

    private void Start()
    {
        // Calculate and store the initial offset between the camera and the object
        offset = transform.position - ObjectToFollow.transform.position;
    }

    private void LateUpdate()
    {
        // Calculate the target position with the maintained offset
        Vector3 targetPosition = ObjectToFollow.transform.position + offset;
        // Smoothly move the camera towards the target position
        transform.position = targetPosition;
    }
}
