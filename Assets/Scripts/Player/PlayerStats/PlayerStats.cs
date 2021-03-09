using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int startCurrency = 0;
    public int currentCurrency = 0;
    public float playerHealth = 20;
    public int staminaStat = 2;
    public float staminaColldown = 6;

    [HideInInspector]
    public float currentHeath;
}
