using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int distanceToCollect = 5;
    private GameObject player;

    private Vector3 playerDirection;
    private Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (player.transform.position - gameObject.transform.position).magnitude;

        if (distanceToPlayer <= distanceToCollect)
        {
            float moveSpeed = 20.0f;

            playerPosition = player.transform.position;
            playerDirection = (playerPosition - transform.position).normalized;

            transform.position += (playerDirection + new Vector3(0, 0.5f, 0))* moveSpeed * Time.deltaTime;
        }
        
    }
}
