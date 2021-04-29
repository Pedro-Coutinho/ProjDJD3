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
            // Normal shoot
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
            // Area of effect shoot
            else if (canShoot && enemyType.areaOfEffect == true)
            {
                animator.SetTrigger("Atack");

                // Draws a raycast downwards to spawn the atack always on the ground

                // Bit shift the index of the layer (8) to get a bit mask
                int layerMask = 1 << 8;
                // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
                layerMask = ~layerMask;

                RaycastHit hit;

                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(player.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 3, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                }
                ring = Instantiate(areaOfEffectWarning, hit.point, Quaternion.identity);
                StartCoroutine(AreaOfEffectAtack(hit.point));
                canShoot = false;
                StartCoroutine(waitCicle(enemyType.shootTimeCicle));
            }
            
        }
        else if (enemyType.areaOfEffect == false)
        {
            animator.SetBool("Atack", false);
        }
    }
    IEnumerator AreaOfEffectAtack(Vector3 ringPos)
    {
        yield return new WaitForSeconds(1f);
        float dist = (player.position - ringPos).magnitude;
        if (dist < 2.5f)
        {
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
