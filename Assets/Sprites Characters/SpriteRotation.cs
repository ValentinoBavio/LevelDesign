using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // search for the camera
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // make sprites rotate toward it
        if (mainCamera != null)
        {
            transform.forward = mainCamera.transform.forward;
        }
    }
}