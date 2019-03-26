using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------
//- This script moves the player
//- By: Peter Schreuder
//---------------

public class PlayerMoving : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 6f, gravity = 20.0f;

    [Header("Gets the Main Camera")]
    [SerializeField]
    private Transform cameraTransform;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        CheckCharacterController();

        //Find the current camera
        cameraTransform = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        //Check if the player is on the ground
        if (controller.isGrounded)
        {
            MoveDirection();
        }

        //Move the player down to simulate gravity
        FakeGravity();

        //Move
        controller.Move(moveDirection * Time.deltaTime);
    }

    void MoveDirection()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
    }

    void FakeGravity()
    {
        //Fake gravity
        moveDirection.y -= gravity * Time.deltaTime;
    }

    void CheckCharacterController()
    {
        //If there is no Controller detected, create one for now
        if (GetComponent<CharacterController>() == null)
        {
            gameObject.AddComponent<CharacterController>();
            Debug.LogWarning("No CharacterController detected! Added one for now.");
        }
    }
}
