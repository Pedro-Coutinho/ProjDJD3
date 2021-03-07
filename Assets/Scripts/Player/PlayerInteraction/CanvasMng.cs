using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script for Canvas Manager that is responsible for displaying and changing
/// the interaction text and the inventory UI
/// </summary>
public class CanvasMng : MonoBehaviour
{
    public GameObject   interactionPanel;
    public Text         interactionText;
    public RawImage[]   inventoryIcons;

    // Start is called before the first frame update
    void Start()
    {
        HideInteractionPanel();
    }

    /// <summary>
    /// Hides the panel with interaction text
    /// </summary>
    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    /// <summary>
    /// Sets the text in the interaction panel and shows it.
    /// </summary>
    /// <param name="textMessage">Interaction text.</param>
    public void ShowInteractionPanel(string textMessage)
    {
        interactionText.text = textMessage;

        interactionPanel.SetActive(true);
    }


    /// <summary>
    /// Sets the inventory icon for a specific slot in inventory.
    /// </summary>
    /// <param name="i">Slot in inventory</param>
    /// <param name="icon">Icon Texture</param>
    public void SetInventoryIcon(int i, Texture icon)
    {
        inventoryIcons[i].texture   = icon;
        inventoryIcons[i].color = Color.clear;
    }

    /// <summary>
    /// Sets the selected inventory icon to be highlighted
    /// </summary>
    /// <param name="n">Selected icon</param>
    /// <param name="inventoryCount">number of inventory slots in use</param>
    public void SetSelectedIcon(int n, int inventoryCount)
    {
        for (int i = 0; i < inventoryCount; ++i)
            inventoryIcons[i].color = Color.gray;
        inventoryIcons[n].color = Color.white;
    }


    /// <summary>
    /// Removes the icons and color from the inventory slots
    /// </summary>
    public void ClearInventoryIcons()
    {
        for (int i = 0; i < inventoryIcons.Length; ++i)
        {
            inventoryIcons[i].texture   = null;
            inventoryIcons[i].color = Color.clear;
        }
    }

}