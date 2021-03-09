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
            animator.SetTrigger("Shoot");
            canShoot = false;
            Instantiate(Arrow, arrowSpawn.position, Quaternion.Euler(0, 90, -90));
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
