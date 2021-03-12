using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PLayerAbility", menuName = "Ability")]
public class PlayerAbilities : ScriptableObject
{
    [SerializeField] private GameObject abilityPrefab;
    [SerializeField] private int level;

    [SerializeField] private enum abilityType { Normal, AreaOfEffect};
    [SerializeField] private abilityType type;

    [SerializeField] private int damage;
}
