using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerController : MonoBehaviour
{
    // Movement tuning (editable in inspector)
    public float speed = 5.0f;
    public float turnSpeed = 5f;
        // Input System action exposed in Inspector for binding (WASD/Arrow keys)
    public InputAction moveAction;

    //Current input value (x= left/right y = forward/back) kept private for internal use
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // read the 2D vector from the moveaction (x: horizontal, y: verticle)
        moveInput = moveAction.ReadValue<Vector2>();

        // Move the vehicle forward/back along local Z using the y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        //rotate around local Y (yaw) using the x component
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
       
    }
}
