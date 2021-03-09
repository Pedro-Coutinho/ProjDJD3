using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats enemyStats;
    public Animator animator;
    public GameObject Currency;

    private GameObject player;
    [HideInInspector]
    public int currentHealth;

    [HideInInspector]
    public bool isDead = false;

    void Start()
    {
        player = GameObject.Find("Player");
        currentHealth = enemyStats.health;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (player.transform.position - gameObject.transform.position).magnitude;
        if (distanceToPlayer < enemyStats.rangeToShoot && isDead == false)
        {
            float step = 100 * Time.deltaTime;

            // Get the normalized direction to the target
            Vector3 directionToTarget = (player.transform.position - transform.position);

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToTarget, step, 0.0f);

            // Draw a ray pointing at our target in
            transform.rotation = Quaternion.LookRotation(newDirection);
            
        }
        if (isDead == false)
            CheckIfDead();

    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            // Set Dead animation Here
            animator.SetBool("Dead", true);
            //gameObject.SetActive(false);
            isDead = true;
            SpawnCurrency();
            DestroyEnemy();
        }
    }

    private void SpawnCurrency()
    {
        for (int i = 0; i < enemyStats.nbrOfCurrencySpawned; i++)
        {
            GameObject c = Instantiate(Currency, gameObject.transform.position, Quaternion.identity);
            c.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * 5, ForceMode.Impulse);
        }
        
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
