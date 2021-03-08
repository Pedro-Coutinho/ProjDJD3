using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiHealth : MonoBehaviour
{
    public PlayerStats playerstats;
    public TextMeshProUGUI healthText;

    private Slider healthBar;
    private void Start()
    {
        playerstats.currentHeath = playerstats.playerHealth;
        healthBar = gameObject.transform.GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerstats.currentHeath < 0)
        {
            playerstats.currentHeath = 0;
        }
        healthText.text =  playerstats.currentHeath + "/10";
        healthBar.value = 1 - (playerstats.playerHealth - playerstats.currentHeath) / playerstats.playerHealth;
    }
}
