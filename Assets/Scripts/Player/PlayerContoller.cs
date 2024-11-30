using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerContoller : MonoBehaviour
{
    public CharacterController characterController;
    public CinemachineFreeLook playerCamera;
    public float walkSpeed = 10f;

    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float playerCameraEulerAnglesY = playerCamera.transform.eulerAngles.y;
        Quaternion quaternionPlayerCameraEulerAnglesY = Quaternion.Euler(0, playerCameraEulerAnglesY, 0);
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector3 movement = quaternionPlayerCameraEulerAnglesY * new Vector3(horizontal, 0, vertical);
        float moveSpeed = MovementSpeed(walkSpeed);
        characterController.Move(movement * moveSpeed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            RotationPlayer(movement);
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void RotationPlayer(Vector3 movement)
    {
        Vector3 direction = movement.normalized;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
        }
    }

    float MovementSpeed(float speed)
    {
        bool sprintPressed = Input.GetKey("left shift");
        bool sneakPressed = Input.GetKey("left ctrl");
        float moveSpeed = speed;
        if (sprintPressed)
        {
            moveSpeed = speed * 1.2f;
        }
        else if (sneakPressed)
        {
            moveSpeed = speed * 0.8f;
        }
        return moveSpeed;
    }
}
