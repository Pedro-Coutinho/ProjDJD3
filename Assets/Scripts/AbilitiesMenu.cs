using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

// THIS CODE IS ALL FUCKED UP, REPEATS IT SELF AND IS JUST PAINFULL TO WATCH
public class AbilitiesMenu : MonoBehaviour
{
    public GameObject AimCanvas;
    public GameObject Ui;
    public GameObject AbilityMenu;
    public Player playerData;
    public PlayerStats playerStats;

    //None Ab
    public PlayerAbilities noneAbility;

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

    public GameObject selectedBtn;

    private GameObject btn;

    private int selectedPannel;
    private EventSystem eventSystem;

    private void Awake()
    {

        // Set the correct ability icons at the start of the game NEEDS FIX, SPRITE CONNOT BE NULL
        if (playerStats.equipedLeftAbility != null)
        {
            equipedLeftAbilitieIcon.sprite = playerStats.equipedLeftAbility.icon;
            menuLeftAbilitieIcon.sprite = playerStats.equipedLeftAbility.icon;
        }
        else
        {
            equipedLeftAbilitieIcon.sprite = null;
            menuLeftAbilitieIcon.sprite = null;
        }

        if (playerStats.equipedRightAbility != null)
        {
            equipedRightAbilitieIcon.sprite = playerStats.equipedRightAbility.icon;
            menuRightAbilitieIcon.sprite = playerStats.equipedRightAbility.icon;
        }
        else
        {
            equipedRightAbilitieIcon.sprite = null;
            menuRightAbilitieIcon.sprite = null;
        }

        
        

        if (playerStats.equipedLeftAbility == null)
        {
            equipedLeftAbilitieIcon.color = new Color32(150, 150, 150, 255);
            menuLeftAbilitieIcon.color = new Color32(150, 150, 150, 255);
        }

        if (playerStats.equipedLeftAbility == null)
        {
            equipedRightAbilitieIcon.color = new Color32(150, 150, 150, 255);
            menuRightAbilitieIcon.color = new Color32(150, 150, 150, 255);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        playerData.playerControls.Gameplay.Menu.performed += ctx => OpenMenu();
        playerData.playerControls.Menu.Exit.performed += ctx => CloseMenu();

        eventSystem = EventSystem.current;
    }

    

    private void OpenMenu()
    {
        // Switch Action Map
        playerData.playerControls.Gameplay.Disable();
        playerData.playerControls.Menu.Enable();

        AimCanvas.SetActive(false);
        Ui.SetActive(false);
        AbilityMenu.SetActive(true);

        // Select the first btn
        eventSystem.SetSelectedGameObject(selectedBtn);
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

                    // Set colors
                    menuLeftAbilitieIcon.color = new Color32(255, 255, 255, 255);
                    equipedLeftAbilitieIcon.color = new Color32(255, 255, 255, 255);

                    // Se if it is already in the other slot and if its not null
                    if (menuRightAbilitieIcon.sprite == null ? false : (pa.name == menuRightAbilitieIcon.sprite.name))
                    {
                        menuRightAbilitieIcon.sprite = null;
                        equipedRightAbilitieIcon.sprite = null;
                        playerStats.equipedRightAbility = noneAbility;

                        // Set colors to gray
                        menuRightAbilitieIcon.color = new Color32(150, 150, 150, 255);
                        equipedRightAbilitieIcon.color = new Color32(150, 150, 150, 255);
                    }
                }
                else if (selectedPannel == 2)
                {
                    playerStats.equipedRightAbility = pa;
                    equipedRightAbilitieIcon.sprite = pa.icon;
                    menuRightAbilitieIcon.sprite = pa.icon;
                    menuRightAbilitieIcon.transform.parent.GetComponent<Button>().Select();

                    // Set Colors
                    menuRightAbilitieIcon.color = new Color32(255, 255, 255, 255);
                    equipedRightAbilitieIcon.color = new Color32(255, 255, 255, 255);

                    // Se if it is already in the other slot and if its not null
                    if (menuLeftAbilitieIcon.sprite == null ? false : (pa.name == menuLeftAbilitieIcon.sprite.name))
                    {
                        menuLeftAbilitieIcon.sprite = null;
                        equipedLeftAbilitieIcon.sprite = null;
                        playerStats.equipedLeftAbility = noneAbility;

                        // Set colors to gray
                        menuLeftAbilitieIcon.color = new Color32(150, 150, 150, 255);
                        equipedLeftAbilitieIcon.color = new Color32(150, 150, 150, 255);
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
                AbilitieSlotsPannel1[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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
                AbilitieSlotsPannel2[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                AbilitieSlotsPannel2[i].transform.parent.GetComponent<Button>().interactable = true;
                i++;
            }

            
        }
        
    }
}
