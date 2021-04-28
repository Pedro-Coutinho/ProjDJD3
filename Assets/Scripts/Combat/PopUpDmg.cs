using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDmg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(destroyThis());
    }

    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
