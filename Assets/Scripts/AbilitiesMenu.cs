using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilitiesMenu : MonoBehaviour
{
    public GameObject AimCanvas;
    public GameObject Ui;
    public GameObject AbilityMenu;
    public Player playerData;

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
}
