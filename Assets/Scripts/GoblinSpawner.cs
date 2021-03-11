using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public GameObject goblinSpawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goblinSpawner.SetActive(true);
        }
    }
}
