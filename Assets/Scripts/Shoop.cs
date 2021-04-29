using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Shoop : MonoBehaviour
{
    public GameObject bookCam;
    public Player playerData;
    public GameObject shoopUI;
    public GameObject selectedBurstBtn;
    public GameObject selectedMeteorBtn;
    public PlayerStats playerStats;
    public TextMeshProUGUI currency;

    public PlayerAbilities meteroAbility;
    public PlayerAbilities burstAbility;

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

            // Set diplayed currency
            currency.text = playerStats.currentCurrency.ToString();
            // Select the correct Btn
            eventSystem.SetSelectedGameObject(selectedMeteorBtn);
            foreach (PlayerAbilities ab in playerStats.posessedAbilities)
            {
                if (ab.name == "Meteor")
                {
                    selectedMeteorBtn.GetComponent<Button>().interactable = false;
                    // Select the correct Btn
                    eventSystem.SetSelectedGameObject(selectedBurstBtn);
                }

                if (ab.name == "Burst")
                {
                    selectedBurstBtn.GetComponent<Button>().interactable = false;
                }
            }

            
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
        if (playerStats.currentCurrency >= 150)
        {
            playerStats.posessedAbilities.Add(meteroAbility);
            playerStats.currentCurrency -= 150;
            currency.text = playerStats.currentCurrency.ToString();
            eventSystem.currentSelectedGameObject.GetComponent<Button>().interactable = false;
            eventSystem.SetSelectedGameObject(selectedBurstBtn);

        }
    }

    public void BuyBurstAbility()
    {
        if (playerStats.currentCurrency >= 100)
        {
            playerStats.posessedAbilities.Add(burstAbility);
            playerStats.currentCurrency -= 100;
            currency.text = playerStats.currentCurrency.ToString();
            eventSystem.currentSelectedGameObject.GetComponent<Button>().interactable = false;
            eventSystem.SetSelectedGameObject(selectedMeteorBtn);
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
