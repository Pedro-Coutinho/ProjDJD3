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
        float step = 100 * Time.deltaTime;
        Vector3 camPos = Camera.main.transform.position;

        // Get the normalized direction to the target
        Vector3 directionToTarget = (camPos - transform.position);

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToTarget * -1, step, 0.0f);

        // Draw a ray pointing at our target in
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
