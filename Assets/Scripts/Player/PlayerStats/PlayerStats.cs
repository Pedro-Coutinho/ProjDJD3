using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float playerHealth = 20;

    [HideInInspector]
    public float currentHeath;
}
