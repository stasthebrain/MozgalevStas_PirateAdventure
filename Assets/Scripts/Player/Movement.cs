using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateQuest
{
    public class Movement : MonoBehaviour
    {

        [SerializeField] private float Speed;
        [SerializeField] private float RunSpeed;
        [SerializeField] private float GroudDrag;
        [SerializeField] private float JumpForce;
        [SerializeField] private float CoolDown;
        [SerializeField] private float AirMultiplier;
        [SerializeField] private float playerHeight;
        [SerializeField] private float GroundRay = 0.2f;

        [SerializeField] private Transform orientation;

        private float multiplier = 10f;
        private float PlayerHeightMultiplier = 0.5f;

        public LayerMask groundMask;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Running = "Running";
        private const string Jump = "Jump";

        float horizontalInput;
        float verticalInput;
        Vector3 moveDirection;

        Rigidbody rb;
        private bool isRunning;
        private bool isGrounded;
        private bool ReadyToJump;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
            ReadyToJump = true;
        }

        private void Update()
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * PlayerHeightMultiplier * GroundRay, groundMask);
            MyInput();
            if (isGrounded)
            {
                rb.drag = GroudDrag;
            }
            else
            {
                rb.drag = 0;
            }
            SpeedControl();
        }

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw(Horizontal);
            verticalInput = Input.GetAxisRaw(Vertical);
            isRunning = Input.GetButton(Running);
            if (Input.GetButtonDown(Jump) && ReadyToJump && isGrounded)
            {
                ReadyToJump = false;
                Jumping();
                Invoke(nameof(JumpReset), CoolDown);
            }
        }

        private void PlayerMove()
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            if (isGrounded)
            {
                rb.AddForce(moveDirection.normalized * (isRunning ? RunSpeed : Speed) * multiplier, ForceMode.Force);
            }
            else if(!isGrounded)
            {
                rb.AddForce(moveDirection.normalized * (isRunning ? RunSpeed : Speed) * multiplier * AirMultiplier, ForceMode.Force);
            }
        }

        private void SpeedControl()
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (flatVelocity.magnitude > (isRunning ? RunSpeed : Speed))
            {
                Vector3 limitedVel = flatVelocity.normalized * (isRunning ? RunSpeed : Speed);
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

        private void Jumping()
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        private void JumpReset()
        {
            ReadyToJump = true;
        }
        

    }
}