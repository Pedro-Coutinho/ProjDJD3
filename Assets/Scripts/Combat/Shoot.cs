using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Shoot : MonoBehaviour
{
    public Player playerData;
    
    public GameObject BasicAtack;
    public TextMeshProUGUI BasicAtackTimer;
    public GameObject Ability_1;
    public TextMeshProUGUI Ability_1Timer;
    public Transform arrowSpawn;

    //public PlayerAbilities[] allOfPlayerAbilities;
    private Animator animator;
    private bool canShoot = true;
    private bool canShootAbility1 = true;

    private Vector3 enemyDirection;
    private Vector3 enemyPosition;

    private GameObject[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerData.playerControls.Gameplay.Shoot.performed += ctx => BasicAbility();
        playerData.playerControls.Gameplay.Abilitiy1.performed += ctx => Ability1();
    }

    // Spawns basic player ability
    private void BasicAbility()
    {
        if (canShoot && playerData.enemylock)
        {
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;
            animator.SetTrigger("Shoot");
            canShoot = false;
            Instantiate(BasicAtack, arrowSpawn.position, Quaternion.LookRotation(enemyDirection));
            StartCoroutine(ShootTime());
        }

    }

    // Spawns ability 1 (Area of Effect)
    private void Ability1()
    {
        if (canShootAbility1 && playerData.enemylock)
        {
            // Calculates Enemy direction
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;

            animator.SetTrigger("Shoot");
            canShootAbility1 = false;
            Instantiate(Ability_1, playerData.currentEnemyPosition + new Vector3(0, -1, 0), Quaternion.LookRotation(enemyDirection));

            // Courotine to ability coolDown
            StartCoroutine(Ability1Time());

            // Courotine to damage player after x time
            StartCoroutine(MeteorDamage(playerData.currentEnemyPosition));
        }
    }

    // Courotine to damage player after x time
    IEnumerator MeteorDamage(Vector3 centerPos)
    {
        yield return new WaitForSeconds(1f);
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemie in Enemies)
        {
            float dist = (enemie.transform.position - centerPos).magnitude;

            // Deals more damage depending on the distance to the center of the spawn
            if (dist < 1)
            {
                enemie.transform.GetComponent<Enemy>().currentHealth -= 3;
            }
            else if (dist < 4)
            {
                enemie.transform.GetComponent<Enemy>().currentHealth -= 2;
            }
            else if (dist < 5)
            {
                enemie.transform.GetComponent<Enemy>().currentHealth -= 1;
            }
        }

    }

    // Courotine to ability coolDown
    IEnumerator Ability1Time()
    {
        // Displays Cooldown time for ability 1.
        float duration = 4;
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            Ability_1Timer.text = (Math.Round(remainingTime, 1)).ToString();
            yield return null;
        }
        
        
        Ability_1Timer.text = string.Empty;
        canShootAbility1 = true;
    }
    IEnumerator ShootTime()
    {
        // Displays cooldown time for Basic atack. 
        float duration = 1f;
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            BasicAtackTimer.text = (Math.Round(remainingTime, 1)).ToString();
            yield return null;
        }
        BasicAtackTimer.text = string.Empty;
        canShoot = true;
    }
}
