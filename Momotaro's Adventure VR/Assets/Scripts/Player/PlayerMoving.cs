using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Find the current camera
        cameraTransform = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            MoveDirection();
        }

        FakeGravity();


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
}
