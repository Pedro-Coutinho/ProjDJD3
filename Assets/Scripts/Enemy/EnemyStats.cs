using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType")]
public class EnemyStats : ScriptableObject
{
    public int health = 2;

    public float rangeToShoot = 3;

    public bool burstShoot = false;

    public bool spreadShoot = false;

    public float shootTimeCicle;

    public int nbrOfCurrencySpawned = 3;
}

