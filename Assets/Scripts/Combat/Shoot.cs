using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Player playerData;
    
    public GameObject BasicAtack;
    public GameObject Ability_1;
    public Transform arrowSpawn;

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
        playerData.playerControls.Gameplay.Shoot.performed += ctx => ShootArrow();
        playerData.playerControls.Gameplay.Abilitiy1.performed += ctx => Ability1();
    }

    private void ShootArrow()
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

    private void Ability1()
    {
        if (canShootAbility1 && playerData.enemylock)
        {
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;
            animator.SetTrigger("Shoot");
            canShootAbility1 = false;
            Instantiate(Ability_1, playerData.currentEnemyPosition + new Vector3(0, -1, 0), Quaternion.LookRotation(enemyDirection));
            StartCoroutine(Ability1Time());

            
            StartCoroutine(MeteorDamage(playerData.currentEnemyPosition));
        }
    }
    IEnumerator MeteorDamage(Vector3 centerPos)
    {
        yield return new WaitForSeconds(1f);
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemie in Enemies)
        {
            float dist = (enemie.transform.position - centerPos).magnitude;
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
    IEnumerator Ability1Time()
    {
        yield return new WaitForSeconds(2);
        canShootAbility1 = true;
    }
    IEnumerator ShootTime()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
