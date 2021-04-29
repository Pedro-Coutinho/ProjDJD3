using System.Collections;
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

    private bool playIdleVariant = true;

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
            playerData.speed = playerData.speed * 10;
            currentSpeed = currentSpeed * 1.5f;
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
        yield return new WaitForSeconds(1 * Time.unscaledDeltaTime);
        playerData.speed = playerData.speed / 10;
        inputs.Gameplay.Enable();
        StopMove();
    }
    // Update is called once per frame
    void Update()
    {
        if (playIdleVariant && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Basic"))
        {
            StartCoroutine(RandomizeIdle());
            playIdleVariant = false;
        }
            
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
        controler.Move((moveDir.normalized * currentSpeed * Time.unscaledDeltaTime) + directionY * Time.unscaledDeltaTime);
    }

    private void StopMove()
    {
        move = Vector2.zero;
        moveDir = new Vector3(0, 0, 0);
        animator.SetBool("Running", false);
    }

    
    private void CalculateMovment()
    {
        float previousSpeed = currentSpeed;
        float horizontal = move.x;
        float vertical = move.y;
        Vector3 directon = new Vector3(horizontal, 0f, vertical).normalized;
        if (directon.magnitude >= 0.8f)
        {
            float targetAngle = Mathf.Atan2(directon.x, directon.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmothVelocity, playerData.turnSmoothTime);

            

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            currentSpeed = playerData.speed * (Math.Abs(horizontal) + Math.Abs(vertical));

            
            animator.SetBool("Running", true);
            //Verifica se a diferença entre a velocidade anterior e a atual é maior do que 3
            if (currentSpeed + 3 < previousSpeed)
                // caso seja soma-se a velocidade atual a diferença entre as duas a dividir por 2
                currentSpeed += (previousSpeed - currentSpeed)/2;

            animator.SetFloat("CurrentSpeed", currentSpeed);

            if (playerData.enemylock == false)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
        }
        else
        {
            currentSpeed -= (currentSpeed * 5) * Time.deltaTime;
            if (currentSpeed < 0f)
                currentSpeed = 0;
                
            animator.SetFloat("CurrentSpeed", currentSpeed);
            animator.SetBool("Running", false);
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
                playerData.currentGravity -= playerData.gravity * Time.unscaledDeltaTime; 
            }

            directionY += gravityDirection * -playerData.currentGravity * Time.unscaledDeltaTime;
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

    IEnumerator RandomizeIdle()
    {
        float random = UnityEngine.Random.Range(0f, 1f);
        if (random >= 0.9f)
            animator.SetTrigger("IdleThrow");
        else if (0.7f <= random && random < 0.9f)
            animator.SetTrigger("IdleKick");
        else if (random < 0.2f)
            animator.SetTrigger("IdleArmStrech");

        Debug.Log(random);
        yield return new WaitForSeconds(UnityEngine.Random.Range(20, 40));
        playIdleVariant = true;
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
