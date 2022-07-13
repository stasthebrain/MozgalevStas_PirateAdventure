using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float runspeed = 8f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 1f;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    Vector3 velocity;
    public CharacterController controller;
    public Transform groundCheck;

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Running = "Running";
    private const string Jump = "Jump";
    private bool isRunning;
    private bool isGrounded;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis(Horizontal);
        float z = Input.GetAxis(Vertical);
        isRunning = Input.GetButton(Running);

        if (Input.GetButtonDown(Jump) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (isRunning ? runspeed : speed) * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
