using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Shoop : MonoBehaviour
{
    public GameObject bookCam;
    public Player playerData;
    public GameObject shoopUI;
    public GameObject selectedBtn;

    private GameObject UI;

    private EventSystem eventSystem;

    private bool playerInZone = false;
    private bool interfaceActive = false;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        playerData.playerControls.Gameplay.Interact.performed += ctx => InteractInterface();
        playerData.playerControls.Shoop.Exit.performed += ctx => ExitShoop();

        eventSystem = EventSystem.current;
    }
    private void InteractInterface()
    {
        if (playerInZone && !interfaceActive)
        {
            
            bookCam.SetActive(true);
            interfaceActive = true;
            UI.SetActive(false);
            shoopUI.SetActive(true);
            // Switch Action Map
            playerData.playerControls.Gameplay.Disable();
            playerData.playerControls.Shoop.Enable();

            // Select the correct Btn
            eventSystem.SetSelectedGameObject(selectedBtn);
        }
        
    }
    private void ExitShoop()
    {
        if (playerInZone)
        {
            bookCam.SetActive(false);
            interfaceActive = false;
            UI.SetActive(true);
            shoopUI.SetActive(false);
            // Switch Action Map
            playerData.playerControls.Shoop.Disable();
            playerData.playerControls.Gameplay.Enable();
        }
    }

    public void BuyMeteorAbility()
    {

    }

    public void BuyBurstAbility()
    {

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
