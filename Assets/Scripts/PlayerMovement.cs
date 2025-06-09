using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController characterController;

    private bool canMove = true;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // 2. Rotate input to isometric direction
        Vector3 isometricInput = Quaternion.Euler(0, 45, 0) * input;

        // 3. Determine current speed
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = canMove ? (isRunning ? runSpeed : walkSpeed) : 0f;

        // 4. Apply movement vector (but preserve Y)
        float movementDirectionY = moveDirection.y;
        moveDirection = isometricInput * speed;
        moveDirection.y = movementDirectionY;

        // 5. Jumping
        if (Input.GetButtonDown("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }

        // 6. Gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // 7. Crouch toggle
        if (Input.GetKey(KeyCode.R) && canMove)
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 6f;
            runSpeed = 12f;
        }

        // 8. Apply movement
        characterController.Move(moveDirection * Time.deltaTime);
    }
}