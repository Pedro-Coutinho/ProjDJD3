using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    void Start()
    {
        // Partical collisions
        var physicsMotion = GetComponentInChildren<RFX4_PhysicsMotion>(true);
        if (physicsMotion != null) physicsMotion.CollisionEnter += CollisionEnter;

        var raycastCollision = GetComponentInChildren<RFX4_RaycastCollision>(true);
        if (raycastCollision != null) raycastCollision.CollisionEnter += CollisionEnter;
        StartCoroutine(DestroyAffterTime());
    }

    private void CollisionEnter(object sender, RFX4_PhysicsMotion.RFX4_CollisionInfo e)
    {
        //Debug.Log(e.HitPoint); //a collision coordinates in world space
        //Debug.Log(e.HitGameObject.name); //a collided gameobject
        //Debug.Log(e.HitCollider.name); //a collided collider :)

        // If hits enemy, takes damage
        if (e.HitGameObject.transform.tag == "Enemy")
            e.HitGameObject.transform.GetComponent<Enemy>().currentHealth -= 1;
    }

    // Destroys this after some time
    IEnumerator DestroyAffterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
