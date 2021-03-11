using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyStats enemyType;
    public Transform player;
    public PlayerStats playerStats;
    public GameObject enemyShoot;
    public GameObject areaOfEffectWarning;

    public Animator animator;

    private bool canShoot = true;

    private Enemy enemy;

    private Vector3 playerDirection;
    private Vector3 playerPosition;

    private GameObject ring;

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
            
            if (canShoot && enemyType.areaOfEffect == false)
            {
                animator.SetBool("Atack", true);
                playerPosition = player.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2.0f), Random.Range(-1f, 1f));
                playerDirection = (playerPosition - gameObject.transform.position).normalized;
                Instantiate(enemyShoot, gameObject.transform.position, Quaternion.LookRotation(playerDirection));
                canShoot = false;

                // Random Time Shoot
                float rnd = Random.Range(enemyType.shootTimeCicle - 0.5f, enemyType.shootTimeCicle + 0.5f);
                StartCoroutine(waitCicle(rnd));
            }
            else if (canShoot && enemyType.areaOfEffect == true)
            {
                animator.SetTrigger("Atack");
                ring = Instantiate(areaOfEffectWarning, player.position, Quaternion.identity);
                StartCoroutine(AreaOfEffectAtack(player.position));
                canShoot = false;
                StartCoroutine(waitCicle(3));
            }
            
        }
        else if (enemyType.areaOfEffect == false)
        {
            animator.SetBool("Atack", false);
        }
    }
    IEnumerator AreaOfEffectAtack(Vector3 ringPos)
    {
        yield return new WaitForSeconds(1);
        float dist = (player.position - ringPos).magnitude;
        if (dist < 3)
        {
            Debug.Log("Entrou");
            playerStats.currentHeath -= 1;
        }
        Destroy(ring);
        Instantiate(enemyShoot, ringPos, Quaternion.identity);
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
