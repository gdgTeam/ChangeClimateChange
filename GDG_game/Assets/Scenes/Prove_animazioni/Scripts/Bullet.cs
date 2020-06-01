using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20f;
    public float life = 1f;

    private int firedByLayer;
    private float lifeTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit, velocity * Time.deltaTime, ~(1<<firedByLayer)))
        {
            transform.position = hit.point;
            Vector3 reflected = Vector3.Reflect(transform.right, hit.normal);
            Vector3 direction = transform.right;
            Vector3 vop = Vector3.ProjectOnPlane(reflected, Vector3.right);
            transform.right = vop;
            transform.rotation = Quaternion.LookRotation(vop, Vector3.right);
            Hit(transform.position, direction, reflected, hit.collider);
        }
        else
        {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        }

        if(Time.time > lifeTimer + life)
        {
            Destroy(gameObject);
        }
    }

    private void Hit(Vector3 position, Vector3 direction, Vector3 reflected, Collider collider)
    {
        //qui posso fare qualcosa con l'oggetto che ho colpito (che sarebbe il collider.gameObject)
        Destroy(gameObject);
    }

    public void fire(Vector3 position, Vector3 euler, int layer) 
    {
        lifeTimer = Time.time;
        transform.position = position;
        transform.eulerAngles = euler;
        transform.position = new Vector3(2, transform.position.y, transform.position.z);
        Vector3 vop = Vector3.ProjectOnPlane(transform.right, Vector3.right);
        transform.right = vop;
        transform.rotation = Quaternion.LookRotation(vop, Vector3.right);
    }
}
