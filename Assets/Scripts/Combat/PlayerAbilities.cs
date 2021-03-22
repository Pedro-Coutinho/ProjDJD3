using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public enum abilityType { Normal, AreaOfEffect, DamageOverTime, Heal };

[CreateAssetMenu(fileName = "PLayerAbility", menuName = "Ability")]
public class PlayerAbilities : ScriptableObject
{
    public abilityType type;

    //  Display always
    public string abilityName;
    public GameObject abilityPrefab;
    public GameObject icon; // May need a difrent icon 
    public int level = 0;
    public float cooldowTime = 0;
    public int range = 0;

    // Normal ability variables 
    public int damage = 0;

    // Area of Effect variables
    public int AreaOfEffect = 0;
    public int damageCenter = 0;
    public int damageMiddle = 0;
    public int damageFar = 0;

    // Damage over time variables
    public float totalTime = 0;
    public float timeIntervalForDamge = 0;

    // Heal
    public int healValue;
}

[CustomEditor(typeof(PlayerAbilities))]
public class AbilitieEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerAbilities playerAbilities = (PlayerAbilities)target;

        // Display always
        playerAbilities.abilityName = (string)EditorGUILayout.TextField("AbilityName", playerAbilities.abilityName);
        playerAbilities.abilityPrefab = (GameObject)EditorGUILayout.ObjectField("Ability Effect", playerAbilities.abilityPrefab, typeof(Object), true);
        playerAbilities.icon = (GameObject)EditorGUILayout.ObjectField("Ability Icon", playerAbilities.icon, typeof(Object), true);
        playerAbilities.cooldowTime = (float)EditorGUILayout.FloatField("CooldownTime", playerAbilities.cooldowTime);
        playerAbilities.level = (int)EditorGUILayout.IntField("Level", playerAbilities.level);

        // Display DropDown
        playerAbilities.type = (abilityType)EditorGUILayout.EnumPopup("AbilitieType", playerAbilities.type);

        // Normal Abilities
        if (playerAbilities.type == abilityType.Normal)
        {
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Normal ability variables");
            playerAbilities.damage = (int)EditorGUILayout.IntField("Damage", playerAbilities.damage);
        }

        // Area of Effect variables
        if (playerAbilities.type == abilityType.AreaOfEffect)
        {
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Area of effect variables");
            playerAbilities.AreaOfEffect = (int)EditorGUILayout.IntField("AreaOfEffect", playerAbilities.AreaOfEffect);
            playerAbilities.damageCenter = (int)EditorGUILayout.IntField("DamageCenter", playerAbilities.damageCenter);
            playerAbilities.damageMiddle = (int)EditorGUILayout.IntField("DamageMiddle", playerAbilities.damageMiddle);
            playerAbilities.damageFar = (int)EditorGUILayout.IntField("DamageFar", playerAbilities.damageFar);
        }

        // Damage over time variables 
        if (playerAbilities.type == abilityType.DamageOverTime)
        {
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Damage over time variables");
            playerAbilities.totalTime = (float)EditorGUILayout.FloatField("TotalTime", playerAbilities.totalTime);
            playerAbilities.timeIntervalForDamge = (float)EditorGUILayout.FloatField("DamagetimeIntreval", playerAbilities.timeIntervalForDamge);
        }

        // Heal variables 
        if (playerAbilities.type == abilityType.DamageOverTime)
        {
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Heal variables");
            playerAbilities.healValue = (int)EditorGUILayout.IntField("HealValue", playerAbilities.healValue);
        }

    }
}