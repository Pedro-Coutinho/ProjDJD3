using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesMenu : MonoBehaviour
{
    public GameObject AimCanvas;
    public GameObject Ui;
    public GameObject AbilityMenu;
    public Player playerData;

    private bool menuOpend = false;
    // Start is called before the first frame update
    void Start()
    {
        playerData.playerControls.Gameplay.Menu.performed += ctx => OpenCloseMenu();
    }

    

    private void OpenCloseMenu()
    {
        if (menuOpend)
        {
            AimCanvas.SetActive(true);
            Ui.SetActive(true);

            AbilityMenu.SetActive(false);
            menuOpend = false;
        }
        else
        {
            AimCanvas.SetActive(false);
            Ui.SetActive(false);

            AbilityMenu.SetActive(true);
            menuOpend = true;
        }
    }
}
