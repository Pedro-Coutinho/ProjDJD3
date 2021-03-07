using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta classe não presta
public class EnemyRightshootPrefab : MonoBehaviour
{
    public PlayerStats playerStats;
    private GameObject player;
    private Vector3 playerDirection;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPosition = player.transform.position;
        playerDirection = ((playerPosition + new Vector3(3, 5, 3)) - transform.position).normalized;
        StartCoroutine(destroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 25.0f;

        transform.position += playerDirection * moveSpeed * Time.deltaTime;
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerStats.currentHeath -= 1;
            Destroy(gameObject);
        }
    }
}
