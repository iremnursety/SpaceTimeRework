using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //public GameObject Player;
    [SerializeField] private CharacterController controller;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform ground;
    [SerializeField] private float distance = 0.3f;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpHeight=1f;
    [SerializeField] private float gravity=-9.81f;

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask mask;
    
    private Vector3 _velocity;
    private void OnValidate()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        #region Movement

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }

        #endregion

        #region Running

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 6.5f;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2f;
            animator.SetBool("isRunning", false);
        }

        #endregion

        #region Jump Zıplama

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded || !isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        #endregion

        #region Gravity Yerçekimi

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }

        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);

        #endregion
    }
}