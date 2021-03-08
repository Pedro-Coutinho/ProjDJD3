using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Player playerData;

    private Vector3 enemyDirection;
    private Vector3 enemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemyPosition = playerData.currentEnemyPosition;
        enemyDirection = (enemyPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 40.0f;

        //Destroy(gameObject, 1);
        transform.position += enemyDirection * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.transform.GetComponent<Enemy>().currentHealth -= 1;
            other.gameObject.transform.GetComponent<Enemy>().animator.SetTrigger("Hit");
            Destroy(gameObject);
        }
    }
}
