using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player variabels
[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class Player : ScriptableObject
{
    [HideInInspector]
    public PlayerControls playerControls;

    
    public bool enemylock;

    [HideInInspector]
    public Vector3 currentEnemyPosition;

    [Header("Movement")]
    [HideInInspector]
    public float speed = 7f;
    public float aimingSpeed = 4.5f;
    public float normalSpeed = 7f;
    public float turnSmoothTime = 0.1f;

    [Header("Gravity")]
    public float gravity;
    public float currentGravity;
    public float constantGravity;
    public float maxGravity;

    [Header("Jump")]
    public float jumpSpeed = 10;
    public float doubleJumpMultiplier = 0.5f;

    [Header("Combat")]
    public int shootDist = 30;

}
