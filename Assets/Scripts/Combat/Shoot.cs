using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Player playerData;
    
    public GameObject Arrow;
    public Transform arrowSpawn;

    private Animator animator;
    private bool canShoot = true;

    private Vector3 enemyDirection;
    private Vector3 enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerData.playerControls.Gameplay.Shoot.performed += ctx => ShootArrow();
    }

    private void ShootArrow()
    {
        if (canShoot && playerData.enemylock)
        {
            enemyPosition = playerData.currentEnemyPosition;
            enemyDirection = (enemyPosition - arrowSpawn.position).normalized;
            animator.SetTrigger("Shoot");
            canShoot = false;
            Instantiate(Arrow, arrowSpawn.position, Quaternion.LookRotation(enemyDirection));
            StartCoroutine(ShootTime());
        }

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
