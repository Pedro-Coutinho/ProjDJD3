using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CastAbilities : MonoBehaviour
{
    public Player playerData;
    public PlayerStats playerStats;

    public Sprite goldFrame;
    public Sprite silverFrame;

    public GameObject BasicAtack;
    public TextMeshProUGUI BasicAtackTimer;
    public Image basicAtackFrame;

    public TextMeshProUGUI Ability_1Timer;
    public Image ability_1Frame;

    public TextMeshProUGUI Ability_2Timer;
    public Image ability_2Frame;

    public Transform arrowSpawn;

    public GameObject PopUpDmg;

    // private variables
    private Animator animator;
    private bool canShoot = true;
    private bool canShootAbility1 = true;
    private bool canShootAbility2 = true;

    private Vector3 enemyDirection;
    private Vector3 enemyPosition;

    private GameObject[] Enemies;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerData.playerControls.Gameplay.Shoot.performed += ctx => CastBasicAbility(0);
        playerData.playerControls.Gameplay.Abilitiy1.performed += ctx => CastAbility(1);
        playerData.playerControls.Gameplay.Ability2.performed += ctx => CastAbility(2);
    }
    

    // Spawns basic player ability
    private void CastBasicAbility(int Ab)
    {
        if (canShoot && playerData.enemylock)
        {
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;
            animator.SetTrigger("Shoot");
            canShoot = false;
            Instantiate(BasicAtack, arrowSpawn.position, Quaternion.LookRotation(enemyDirection));
            StartCoroutine(ShootTime(Ab, 1));

            // Set Frame
            basicAtackFrame.sprite = silverFrame;
        }

    }

    // Spawns ability 1 (Area of Effect)
    private void CastAbility(int Ab)
    {
        if (Ab == 1)
        {
            if (playerStats.equipedLeftAbility.abilityName == "Meteor" )
                CastMeteorAbility(Ab);
            if (playerStats.equipedLeftAbility.abilityName == "Burst")
                CastBurstAbility(Ab);
            if (playerStats.equipedLeftAbility.abilityName == "Burn")
                CastBurn(Ab);
        }


        if (Ab == 2)
        {
            if (playerStats.equipedRightAbility.abilityName == "Meteor")
                CastMeteorAbility(Ab);
            if (playerStats.equipedRightAbility.abilityName == "Burst")
                CastBurstAbility(Ab);
            if (playerStats.equipedRightAbility.abilityName == "Burn")
                CastBurn(Ab);
        }
        
    }
    private void CastBurn(int Ab)
    {

    }

    // Burst ability shot
    private void CastBurstAbility(int Ab)
    {
        if (playerData.enemylock)
        {
            // Calculates Enemy direction
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;

            animator.SetTrigger("Shoot");
            if (Ab == 1 && canShootAbility1)
            {
                canShootAbility1 = false;
                Instantiate(playerStats.equipedLeftAbility.abilityPrefab, arrowSpawn.position, Quaternion.LookRotation(enemyDirection));

                // Courotine to ability coolDown
                StartCoroutine(ShootTime(Ab, playerStats.equipedLeftAbility.cooldowTime));

                // Set Frame
                ability_1Frame.sprite = silverFrame;
            }
            else if (Ab == 2 && canShootAbility2)
            {
                canShootAbility2 = false;
                Instantiate(playerStats.equipedRightAbility.abilityPrefab, arrowSpawn.position, Quaternion.LookRotation(enemyDirection));

                // Courotine to ability coolDown
                StartCoroutine(ShootTime(Ab, playerStats.equipedRightAbility.cooldowTime));

                // Set Frame
                ability_2Frame.sprite = silverFrame;
            }
            
        }

    }
    

    // Meteor ability shoot
    private void CastMeteorAbility(int Ab)
    {
        if (playerData.enemylock)
        {
            // Calculates Enemy direction
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;

            animator.SetTrigger("Shoot");
            if (Ab == 1 && canShootAbility1)
            {
                canShootAbility1 = false;
                Instantiate(playerStats.equipedLeftAbility.abilityPrefab, playerData.currentEnemyPosition + new Vector3(0, -1, 0), Quaternion.LookRotation(enemyDirection));
                // Courotine to ability coolDown
                StartCoroutine(ShootTime(Ab, playerStats.equipedLeftAbility.cooldowTime));
                // Set Frame
                ability_1Frame.sprite = silverFrame;
                // Courotine to damage player after x time
                StartCoroutine(MeteorDamage(playerData.currentEnemyPosition));
            }
            else if (Ab == 2 && canShootAbility2)
            {
                canShootAbility2 = false;
                Instantiate(playerStats.equipedRightAbility.abilityPrefab, playerData.currentEnemyPosition + new Vector3(0, -1, 0), Quaternion.LookRotation(enemyDirection));
                // Courotine to ability coolDown
                StartCoroutine(ShootTime(Ab, playerStats.equipedRightAbility.cooldowTime));
                // Set Frame
                ability_2Frame.sprite = silverFrame;
                // Courotine to damage player after x time
                StartCoroutine(MeteorDamage(playerData.currentEnemyPosition));
            }
            
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
                GameObject pText = Instantiate(PopUpDmg, enemie.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                pText.GetComponent<TextMeshPro>().text = 3.ToString();
            }
            else if (dist < 4)
            {
                enemie.transform.GetComponent<Enemy>().currentHealth -= 2;
                GameObject pText = Instantiate(PopUpDmg, enemie.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                pText.GetComponent<TextMeshPro>().text = 2.ToString();
            }
            else if (dist < 5)
            {
                enemie.transform.GetComponent<Enemy>().currentHealth -= 1;
                GameObject pText = Instantiate(PopUpDmg, enemie.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                pText.GetComponent<TextMeshPro>().text = 1.ToString();
            }
        }

    }


    // Ability cooldown 
    IEnumerator ShootTime(int Ab, float duration)
    {
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if  (Ab == 0)
                BasicAtackTimer.text = (Math.Round(remainingTime, 1)).ToString();
            else if (Ab == 1)
                Ability_1Timer.text = (Math.Round(remainingTime, 1)).ToString();
            else if (Ab == 2)
                Ability_2Timer.text = (Math.Round(remainingTime, 1)).ToString();
            yield return null;
        }

        // Set Frame
        if (Ab == 0)
        {
            canShoot = true;
            BasicAtackTimer.text = string.Empty;
            basicAtackFrame.sprite = goldFrame;
        }
        else if (Ab == 1)
        {
            Ability_1Timer.text = string.Empty;
            canShootAbility1 = true;
            ability_1Frame.sprite = goldFrame;
        }
        else if (Ab == 2)
        {
            Ability_2Timer.text = string.Empty;
            canShootAbility2 = true;
            ability_2Frame.sprite = goldFrame;
        }

    }
}
