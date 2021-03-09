﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.InputSystem;
using System.Runtime.InteropServices.ComTypes;
using Cinemachine;
using System;

public class ThirdPersonMovment : MonoBehaviour
{
    PlayerControls inputs;
    public GameObject MainCamera;
    public Player playerData;
    public PlayerStats playerStats;
    
    public Transform cam;
    public GameObject[] staminaBars;
    //public ParticleSystem doubleJumpParticalLeft;
    //public ParticleSystem doubleJumpParticalRight;

    private CharacterController controler;
    private Animator animator;
    private float turnSmothVelocity;

    private float currentSpeed;

    private Vector3 gravityDirection;
    private Vector3 directionY;


    private bool canDoubleJump = false;

    private Vector3 moveDir;
    private Vector2 move;

    private int currentStamina; 

    private void Awake()
    {
        UpdateStaminaBar();
        currentStamina = playerStats.staminaStat;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gravityDirection = Vector3.down;

        inputs = new PlayerControls();

        playerData.playerControls = inputs;


        inputs.Gameplay.Jump.performed += ctx => Jump();

        inputs.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputs.Gameplay.Move.canceled += ctx => StopMove();

        inputs.Gameplay.Roll.performed += ctx => Roll();

        controler = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        
    }

    private void UpdateStaminaBar()
    {
        // Set Stamina Bars
        for (int i = 0; i < playerStats.staminaStat; i++)
        {
            staminaBars[i].SetActive(true);
        }
    }

    private void Roll()
    {
        if (currentStamina > 0)
        {
            staminaBars[currentStamina - 1].SetActive(false);
            currentStamina--;
            StartCoroutine(StaminaColldown());
            Vector3 temp = moveDir;
            inputs.Gameplay.Disable();
            moveDir = temp;
            animator.SetTrigger("Roll");
            StartCoroutine(EnableInputsAfterRoll());
        }
        
    }
    IEnumerator StaminaColldown()
    {
        yield return new WaitForSeconds(playerStats.staminaColldown);
        staminaBars[currentStamina].SetActive(true);
        currentStamina++;
    }
    IEnumerator EnableInputsAfterRoll()
    {
        Debug.Log(moveDir);
        yield return new WaitForSeconds(1);
        inputs.Gameplay.Enable();
        StopMove();
    }
    // Update is called once per frame
    void Update()
    {
        CheckIfIsFalling();
        Gravity();
        CalculateMovment();
        UpdateMov();
    }

    private void CheckIfIsFalling()
    {
        if (IsGrounded())
        {
            animator.SetBool("Falling", false);
        }
        else
        {
            animator.SetBool("Falling", true);
        }
    }

    private void UpdateMov()
    {
        controler.Move((moveDir.normalized * currentSpeed * Time.deltaTime) + directionY * Time.deltaTime);
    }

    private void StopMove()
    {
        move = Vector2.zero;
        moveDir = new Vector3(0, 0, 0);
        animator.SetBool("Running", false);
    }
    private void CalculateMovment()
    {
        float horizontal = move.x;
        float vertical = move.y;
        Vector3 directon = new Vector3(horizontal, 0f, vertical).normalized;
        if (directon.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directon.x, directon.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmothVelocity, playerData.turnSmoothTime);

            

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            currentSpeed = playerData.speed * (Math.Abs(horizontal) + Math.Abs(vertical));
            animator.SetBool("Running", true);

            if (playerData.enemylock == false)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

        }
        if (playerData.enemylock == true)
        {
            transform.rotation = Quaternion.Euler(0f, MainCamera.transform.rotation.eulerAngles.y, 0f);
        }

    }

    private void Gravity()
    {
        if (gameObject.transform.GetComponent<CharacterController>().isGrounded == false)
        {
            if (playerData.currentGravity > playerData.maxGravity)
            {
                playerData.currentGravity -= playerData.gravity * Time.deltaTime;
            }

            directionY += gravityDirection * -playerData.currentGravity * Time.deltaTime;
        }
        
    }
    private bool IsGrounded()
    {
        return controler.isGrounded;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            canDoubleJump = true;
            animator.SetTrigger("Jump");
            directionY.y = playerData.jumpSpeed;
        }
        else if (canDoubleJump)
        {
            //doubleJumpParticalLeft.Play();
            //doubleJumpParticalRight.Play();
            animator.SetTrigger("DoubleJump");
            directionY.y = playerData.jumpSpeed * playerData.doubleJumpMultiplier;
            canDoubleJump = false;
        }

    }

    private void OnEnable()
    {
        inputs.Gameplay.Enable();
    }
    private void OnDisable()
    {
        inputs.Gameplay.Disable();
    }

}
