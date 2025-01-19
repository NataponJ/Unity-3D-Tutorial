using Cinemachine;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public CharacterController characterController;
    public CinemachineFreeLook playerCamera;
    public float walkSpeed = 10f;

    private float jumpHeight = 2f;
    private float gravityValue = -9.81f;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        JumpMovement();
        GravityValue();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float playerCameraEulerAnglesY = playerCamera.transform.eulerAngles.y;
        Quaternion quaternionPlayerCameraEulerAnglesY = Quaternion.Euler(0.0f, playerCameraEulerAnglesY, 0.0f);
        Vector3 movement = quaternionPlayerCameraEulerAnglesY * new Vector3(horizontal, 0.0f, vertical);
        float moveSpeed = MovementSpeed(walkSpeed);
        characterController.Move(movement * moveSpeed * Time.deltaTime);
        if (movement != Vector3.zero)
        {
            RotationPlayer(movement);
        }
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

    void JumpMovement()
    {
        if (groundedPlayer && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0.0f;
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravityValue);
            groundedPlayer = false;
        }
    }

    void GravityValue()
    {
        playerVelocity.y += gravityValue * 2f * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundedPlayer = true;
        } else
        {
            groundedPlayer = false;
        }
    }
}
