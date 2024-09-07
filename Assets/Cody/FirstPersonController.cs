using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private CharacterController characterController;
    private Vector3 velocity;
    private Transform cameraTransform;

    void Start()
    {
        // Get the CharacterController component on the player
        characterController = GetComponent<CharacterController>();

        // Get the camera attached to the player
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        MovePlayer();
        LookAround();
        ApplyGravity();
    }

    void MovePlayer()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        // Create a movement vector
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player using the CharacterController
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    void LookAround()
    {
        // Get mouse input for camera movement
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // Rotate the player object (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera (pitch), but clamp it so the player can't look too far up/down
        cameraTransform.localRotation = Quaternion.Euler(
            Mathf.Clamp(cameraTransform.localRotation.eulerAngles.x - mouseY, -90f, 90f),
            cameraTransform.localRotation.eulerAngles.y,
            0f
        );
    }

    void ApplyGravity()
    {
        // Apply gravity manually to the player
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep grounded
        }

        // Apply jump force
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Apply gravity continuously
        velocity.y += gravity * Time.deltaTime;

        // Move the player downwards based on gravity
        characterController.Move(velocity * Time.deltaTime);
    }
}
