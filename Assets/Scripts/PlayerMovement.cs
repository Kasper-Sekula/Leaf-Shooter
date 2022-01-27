using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const float GRAVITY = -8.81f;

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float sprintSpeed = 20f;

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void CheckInput()
    {
        PlayerFreeFall();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * sprintSpeed * Time.deltaTime);
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * movementSpeed * Time.deltaTime);
        }
    }

    private void PlayerJump()
    {

    }

    private void PlayerFreeFall()
    {

    }
}
