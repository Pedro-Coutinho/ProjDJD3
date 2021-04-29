using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrencyManager : MonoBehaviour
{
    public TextMeshProUGUI currencyText;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.currentCurrency = playerStats.startCurrency;
        currencyText.text = playerStats.startCurrency.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Currency")
        {
            playerStats.currentCurrency += UnityEngine.Random.Range(24, 35);
            Destroy(other.gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (playerStats.currentCurrency != Convert.ToInt32(currencyText.text))
        {
            currencyText.text = playerStats.currentCurrency.ToString();
        }
    }
}
