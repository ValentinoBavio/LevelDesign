using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{   
    public float speed = 5f;

    private float gravity = -9.81f;
    private CharacterController controller;
    private Vector3 velocity;

    public Camera playerCamera;
    public float normalFOV = 60f;
    public float zoomFOV = 30f;
    public float zoomSpeed = 10f;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        playerCamera.fieldOfView = normalFOV;
    }

    void Update()
    {
        
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            input.y += 1;

        if (Keyboard.current.sKey.isPressed)
            input.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            input.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            input.x += 1;

        Vector3 movement = transform.right * input.x + transform.forward * input.y;
        controller.Move(movement.normalized * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        if (Mouse.current.rightButton.isPressed)
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView,zoomFOV,zoomSpeed * Time.deltaTime);
        }
        else
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView,normalFOV,zoomSpeed * Time.deltaTime);
        }
    }
}