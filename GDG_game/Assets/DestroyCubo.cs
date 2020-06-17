using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubo : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisione rilevata");
        if(collision.collider.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet Collision");
            Destroy(gameObject);
        }
    }
}
