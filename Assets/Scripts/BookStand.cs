using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BookStand : MonoBehaviour
{
    private Animator animator;
    public GameObject bookCam;
    public Player playerData;

    private bool playerInZone = false;
    private bool interfaceActive = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerData.playerControls.Gameplay.Interact.performed += ctx => InteractInterface();
    }
    private void InteractInterface()
    {
        if (playerInZone && !interfaceActive)
        {
            
            bookCam.SetActive(true);
            interfaceActive = true;
        }
        else
        {
            bookCam.SetActive(false);
            interfaceActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("BookUp");
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("BookDown");
            playerInZone = false;
            bookCam.SetActive(false);
        }
    }
}
