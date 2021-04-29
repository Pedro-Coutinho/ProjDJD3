using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoop : MonoBehaviour
{
    public GameObject bookCam;
    public Player playerData;
    private GameObject UI;

    private bool playerInZone = false;
    private bool interfaceActive = false;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        playerData.playerControls.Gameplay.Interact.performed += ctx => InteractInterface();
    }
    private void InteractInterface()
    {
        if (playerInZone && !interfaceActive)
        {

            bookCam.SetActive(true);
            interfaceActive = true;
            UI.SetActive(false);
        }
        else if (playerInZone)
        {
            bookCam.SetActive(false);
            interfaceActive = false;
            UI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
            bookCam.SetActive(false);
            UI.SetActive(true);
        }
    }
}
