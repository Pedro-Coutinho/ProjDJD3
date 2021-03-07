using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyStats enemyType;
    public Transform player;
    public GameObject enemyShoot;
    public GameObject enemyRightShoot;
    public GameObject enemyLeftShoot;

    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (player.position - gameObject.transform.position).magnitude;
        if (distanceToPlayer < enemyType.rangeToShoot)
        {
            if (canShoot && enemyType.burstShoot == false && enemyType.spreadShoot == false)
            {
                Instantiate(enemyShoot, gameObject.transform.position, Quaternion.identity);
                canShoot = false;
                StartCoroutine(waitCicle(enemyType.shootTimeCicle));
            }
            else if (canShoot && enemyType.burstShoot == true)
            {
                canShoot = false;
                StartCoroutine(burstCicle(enemyType.shootTimeCicle));
            }
            else if (canShoot && enemyType.spreadShoot == true)
            {
                Instantiate(enemyShoot, gameObject.transform.position, Quaternion.identity);
                Instantiate(enemyRightShoot, gameObject.transform.position, Quaternion.identity);
                Instantiate(enemyLeftShoot, gameObject.transform.position, Quaternion.identity);
                canShoot = false;
                StartCoroutine(waitCicle(enemyType.shootTimeCicle));
            }
            
        }
    }

    IEnumerator waitCicle( float waitTime)
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
