using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float GRAVITY = -8.81f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] float jumpHeight = 3f;


    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float sprintSpeed = 20f;

    CharacterController characterController;
    bool isGrounded;
    Vector3 velocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void CheckInput()
    {
        PlayerFreeFall();
        PlayerXZMovement();
        PlayerJump();
    }

    private void PlayerFreeFall()
    {
        velocity.y += GRAVITY * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void PlayerXZMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * sprintSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * movementSpeed * Time.deltaTime);
        }
    }

    private void PlayerJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);
        }
    }
}
