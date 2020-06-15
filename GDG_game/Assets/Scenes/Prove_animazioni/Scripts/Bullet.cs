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
            Vector3 reflected = Vector3.Reflect(transform.forward, hit.normal);
            Vector3 direction = transform.forward;
            Vector3 vop = Vector3.ProjectOnPlane(reflected, Vector3.forward);
            transform.forward = vop;
            transform.rotation = Quaternion.LookRotation(vop, Vector3.forward);
            Hit(transform.position, direction, reflected, hit.collider);
        }
        else
        {
            transform.Translate(-Vector3.forward * velocity * Time.deltaTime);
        }

        if(Time.time > lifeTimer + life)
        {
            Destroy(gameObject);
        }
    }

    private void Hit(Vector3 position, Vector3 direction, Vector3 reflected, Collider collider)
    {
        //qui posso fare qualcosa con l'oggetto che ho colpito (che sarebbe il collider.gameObject)
        if(collider.gameObject.transform.tag == "Robot")
        {

        }
        Destroy(gameObject);
    }

    public void fire(Vector3 position, Vector3 euler, int layer) 
    {
        lifeTimer = Time.time;
        transform.position = position;
        transform.eulerAngles = new Vector3(euler.x, -euler.y, -euler.z);
        //cambiare il valore di x a seconda della profondità del personaggio
       // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 vop = Vector3.ProjectOnPlane(transform.forward, Vector3.right);
        transform.forward = vop;
        transform.rotation = Quaternion.LookRotation(vop, Vector3.forward);
    }
}
