using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ParticleCollision : MonoBehaviour
{
    public GameObject PopUpDmg;
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
        {
            // NEEDS WORK
            int critChance = Random.Range(0, 100);
            if (critChance < 20)
            {
                GameObject pText = Instantiate(PopUpDmg, e.HitPoint + new Vector3(0, 1, 0), Quaternion.identity);

                
                pText.GetComponent<TextMeshPro>().color = new Color(255, 239, 0, 255);
                Debug.Log(transform.name);
                if (transform.name == "Burst(Clone)")
                {
                    pText.GetComponent<TextMeshPro>().text = 5.ToString();
                    e.HitGameObject.transform.GetComponent<Enemy>().currentHealth -= 5;
                } 
                else
                {
                    pText.GetComponent<TextMeshPro>().text = 2.ToString();
                    e.HitGameObject.transform.GetComponent<Enemy>().currentHealth -= 2;
                }
                    
            }
            else
            {
                GameObject pText = Instantiate(PopUpDmg, e.HitPoint + new Vector3(0, 1, 0), Quaternion.identity);

                Debug.Log(transform.name);
                pText.GetComponent<TextMeshPro>().text = 1.ToString();
                pText.GetComponent<TextMeshPro>().color = new Color(255, 255, 255, 255);

                if (transform.name == "Burst(Clone)")
                {
                    pText.GetComponent<TextMeshPro>().text = 3.ToString();
                    e.HitGameObject.transform.GetComponent<Enemy>().currentHealth -= 3;
                }  
                else
                {
                    pText.GetComponent<TextMeshPro>().text = 1.ToString();
                    e.HitGameObject.transform.GetComponent<Enemy>().currentHealth -= 1;
                }
                    
            }
            
        }
            
    }

    // Destroys this after some time
    IEnumerator DestroyAffterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
