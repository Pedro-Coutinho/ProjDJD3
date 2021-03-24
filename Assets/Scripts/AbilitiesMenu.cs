using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class AbilitiesMenu : MonoBehaviour
{
    public GameObject AimCanvas;
    public GameObject Ui;
    public GameObject AbilityMenu;
    public Player playerData;
    public PlayerStats playerStats;

    // Swap Abilities Pannels
    public GameObject AbilitiesPannel_1;
    public GameObject AbilitiesPannel_2;

    // Ui Swapable Abilitie Icons
    public Image equipedLeftAbilitieIcon;
    public Image equipedRightAbilitieIcon;

    // Menu Swapable Ability Icons
    public Image menuLeftAbilitieIcon;
    public Image menuRightAbilitieIcon;

    public GameObject[] AbilitieSlotsPannel1;
    public GameObject[] AbilitieSlotsPannel2;

    private GameObject btn;

    private int selectedPannel;

    // Start is called before the first frame update
    void Start()
    {
        playerData.playerControls.Gameplay.Menu.performed += ctx => OpenMenu();
        playerData.playerControls.Menu.Exit.performed += ctx => CloseMenu();
    }

    

    private void OpenMenu()
    {
        // Switch Action Map
        playerData.playerControls.Gameplay.Disable();
        playerData.playerControls.Menu.Enable();

        AimCanvas.SetActive(false);
        Ui.SetActive(false);
        AbilityMenu.SetActive(true);
    }
    private void CloseMenu()
    {
        // Switch Action Map
        playerData.playerControls.Menu.Disable();
        playerData.playerControls.Gameplay.Enable();

        AimCanvas.SetActive(true);
        Ui.SetActive(true);

        AbilityMenu.SetActive(false);
    }

    // Swaps player ability
    public void SwapAbility()
    {
        btn = EventSystem.current.currentSelectedGameObject;

        Debug.Log(btn.transform.Find("AbilityIcon").GetComponent<Image>().sprite.name);

        // Find the correct abilitie to swap and swap it
        foreach (PlayerAbilities pa in playerStats.posessedAbilities)
        {
            if (pa.name == btn.transform.Find("AbilityIcon").GetComponent<Image>().sprite.name)
            {
                if (selectedPannel == 1)
                {
                    playerStats.equipedLeftAbility = pa;
                    equipedLeftAbilitieIcon.sprite = pa.icon;
                    menuLeftAbilitieIcon.sprite = pa.icon;
                    menuLeftAbilitieIcon.transform.parent.GetComponent<Button>().Select();

                    // Se if it is already in the other slot MAKES AN ERROR IF SPRITE IS NULL
                    if (pa.name == menuRightAbilitieIcon.sprite.name)
                    {
                        menuRightAbilitieIcon.sprite = null;
                    }
                }
                else if (selectedPannel == 2)
                {
                    playerStats.equipedRightAbility = pa;
                    equipedRightAbilitieIcon.sprite = pa.icon;
                    menuRightAbilitieIcon.sprite = pa.icon;
                    menuRightAbilitieIcon.transform.parent.GetComponent<Button>().Select();
                    // Se if it is already in the other slot
                    if (pa.name == menuLeftAbilitieIcon.sprite.name)
                    {
                        menuLeftAbilitieIcon.sprite = null;
                    }
                }

                // Close pannels
                AbilitiesPannel_1.SetActive(false);
                AbilitiesPannel_2.SetActive(false);

            }
        }
    }

    public void OpenAbilities_1Pannel()
    {
        selectedPannel = 1;
        AbilitiesPannel_1.SetActive(true);
        AbilitiesPannel_2.SetActive(false);

        // Set the correct Icons
        int i = 0;
        foreach(PlayerAbilities pa in playerStats.posessedAbilities)
        {
            if (pa.name != "MainAbility")
            {
                AbilitieSlotsPannel1[i].GetComponent<Image>().sprite = pa.icon;
                AbilitieSlotsPannel1[i].transform.parent.GetComponent<Button>().interactable = true;
                i++;
            }
            
        }
    }
    public void OpenAbilities_2Pannel()
    {
        selectedPannel = 2;
        AbilitiesPannel_1.SetActive(false);
        AbilitiesPannel_2.SetActive(true);
        // Set the correct icons
        int i = 0;
        foreach (PlayerAbilities pa in playerStats.posessedAbilities)
        {
            if (pa.name != "MainAbility")
            {
                AbilitieSlotsPannel2[i].GetComponent<Image>().sprite = pa.icon;
                AbilitieSlotsPannel2[i].transform.parent.GetComponent<Button>().interactable = true;
                i++;
            }

            
        }
        
    }
}
