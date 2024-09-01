using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject.transform.parent.gameObject);
    }
}
