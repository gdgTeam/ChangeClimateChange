using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics;
using System.Security.Cryptography;
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
            if (Physics.Raycast(transform.position, transform.right, out hit, velocity * Time.deltaTime, ~(1<<firedByLayer)))
            {
                transform.position = hit.point;
                //Vector3 reflected = Vector3.Reflect(transform.forward, hit.normal);
                Vector3 direction = transform.forward;
                //Vector3 vop = Vector3.ProjectOnPlane(reflected, Vector3.forward);
                //transform.forward = vop;
                //transform.rotation = Quaternion.LookRotation(vop, Vector3.forward);
                //Hit(transform.position, direction, reflected, hit.collider);
            }
            else
            {
                transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            }

            if (Time.time > lifeTimer + life)
            {
                Destroy(gameObject);
            }
        }

        private void Hit(Vector3 position, Vector3 direction, Vector3 reflected, Collider collider)
        {

            //qui posso fare qualcosa con l'oggetto che ho colpito (che sarebbe il collider.gameObject)

            
            /*if (collider.gameObject.transform.tag == "Robot")
            {
                UnityEngine.Debug.Log("HittingRobot");
                RobotControl robotControl = collider.gameObject.GetComponent<RobotControl>();
                Transform[] ts = collider.gameObject.transform.GetComponentsInChildren<Transform>();
                if (robotControl.hit == 0)
                {
                    foreach (Transform t in ts)
                    {
                        if (t.gameObject.name == "Scintille")
                        {
                            t.gameObject.active = true;
                        }
                    }
                    robotControl.hit = robotControl.hit + 1;
                }

                if (robotControl.hit == 1)
                {
                    foreach (Transform t in ts)
                    {
                        if (t.gameObject.name == "Scintille_1")
                        {
                            t.gameObject.active = true;
                        }
                    }
                    robotControl.hit = robotControl.hit + 1;
                }

                if (robotControl.hit == 2)
                {
                    foreach (Transform t in ts)
                    {
                        if (t.gameObject.name == "WhiteSmoke")
                        {
                            t.gameObject.active = true;
                        }
                    }
                    robotControl.hit = robotControl.hit + 1;
                }
            }

            if (collider.gameObject.transform.tag == "CuboProva")
            {
                Destroy(collider.gameObject);
            }
            Destroy(gameObject);*/
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

    public void fire_prova(Vector3 startPosition, Vector3 targetPosition)
    {
        lifeTimer = Time.time;
        transform.position = startPosition;
        targetPosition = new Vector3(targetPosition.x + 0.5f, targetPosition.y, targetPosition.z);
        Vector3 dir = (targetPosition - startPosition).normalized;
        this.transform.forward = dir;
        UnityEngine.Debug.DrawRay(this.transform.position, this.transform.forward, Color.cyan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("Collisione con: " + collision.gameObject);
        Collider collider = collision.collider;

        if (collider.gameObject.transform.tag == "Robot")
        {
            Transform hips = collider.gameObject.transform.GetChild(0);
            RobotControl robotControl = collider.gameObject.GetComponent<RobotControl>();
            UnityEngine.Debug.Log(robotControl.hit);
            if (robotControl.hit == 0)
            {
                hips.GetChild(3).gameObject.active = true;
                robotControl.hit = robotControl.hit + 1;
            }

            else if (robotControl.hit == 1)
            {
                hips.GetChild(4).gameObject.active = true;
                robotControl.hit = robotControl.hit + 1;
            }

            else if (robotControl.hit == 2)
            {
                hips.GetChild(5).gameObject.active = true;
                robotControl.hit = robotControl.hit + 1;
            }
        }

        if (collider.gameObject.transform.tag == "CuboProva")
        {
            UnityEngine.Debug.Log("Oggetto distrutto");
            Destroy(collider.gameObject);
        }
        if(collider.gameObject.transform.tag != "Player")
            Destroy(gameObject);

    }
}
