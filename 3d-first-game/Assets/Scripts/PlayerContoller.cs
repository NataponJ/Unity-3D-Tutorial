using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;
    public Transform player;
    private float defaultPosition;

    // Speed at which the player moves.
    public float speed = 0;
    public float sprint = 0;
    public float sneak = 0;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        defaultPosition = player.position.y;
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        bool sprintPressed = Input.GetKey("left shift");
        bool sneakPressed = Input.GetKey("left ctrl");
        bool jumpPressed = Input.GetKey("space");
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        float moveSpeed = speed;
        if (sprintPressed && !sneakPressed)
        {
            moveSpeed = sprint + speed;
        } else if (!sprintPressed && sneakPressed)
        {
            moveSpeed = speed - sneak;
        } //  && player.position.y <= 0.1f
        if (jumpPressed && player.position.y <= 0.1f)
        {
            Vector3 jumpMovement = new Vector3(movementX, 3.0f, movementY);
            rb.AddForce(jumpMovement * 10000);
        }
        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * moveSpeed);
    }
}
