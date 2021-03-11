using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyStats enemyType;
    public Transform player;
    public GameObject enemyShoot;

    public Animator animator;

    private bool canShoot = true;

    private Enemy enemy;

    private Vector3 playerDirection;
    private Vector3 playerPosition;

    private void Start()
    {
        enemy = gameObject.transform.GetComponent<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (player.position - gameObject.transform.position).magnitude;
        if (distanceToPlayer < enemyType.rangeToShoot && enemy.isDead == false)
        {
            animator.SetBool("Atack", true);
            if (canShoot && enemyType.burstShoot == false && enemyType.spreadShoot == false)
            {
                playerPosition = player.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2.0f), Random.Range(-1f, 1f));
                playerDirection = (playerPosition - gameObject.transform.position).normalized;
                Instantiate(enemyShoot, gameObject.transform.position, Quaternion.LookRotation(playerDirection));
                canShoot = false;

                // Random Time Shoot
                float rnd = Random.Range(enemyType.shootTimeCicle - 0.5f, enemyType.shootTimeCicle + 0.5f);
                StartCoroutine(waitCicle(rnd));
            }
            
        }
        else
        {
            animator.SetBool("Atack", false);
        }
    }

    IEnumerator waitCicle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    IEnumerator burstCicle(float waitTime)
    {
        Instantiate(enemyShoot, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(enemyShoot, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(enemyShoot, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
