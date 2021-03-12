using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PLayerAbility", menuName = "Ability")]
public class PlayerAbilities : ScriptableObject
{
    [SerializeField] private GameObject abilityPrefab;
    [SerializeField] private int level = 0;

    [SerializeField] private enum abilityType { Normal, AreaOfEffect};
    [SerializeField] private abilityType type;

    [SerializeField] private int cooldowTime = 0;
    [SerializeField] private int range = 0;

    [Header("In case of Type Normal Fill this")]
    [SerializeField] private int damage = 0;

    [Header("In case of Type Area of Effect Fill this")]
    [SerializeField] private int AreaOfEffect = 0;
    [SerializeField] private int damageCenter = 0;
    [SerializeField] private int damageMiddle = 0;
    [SerializeField] private int damageFar = 0;
}
