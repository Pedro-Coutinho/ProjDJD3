using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public GameObject goblinSpawner;

    // Activates the spawner when the player enters the collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goblinSpawner.SetActive(true);
        }
    }
}
