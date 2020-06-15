﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterNavController : MonoBehaviour
{
    //[SerializeField] private Camera _camera;
     public GameObject _targetFeedback;

    private NavMeshAgent _navMeshAgent;
    private bool fatto=false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
       /* if (_targetFeedback != null)
            _targetFeedback.SetActive(false);*/
    }


    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _navMeshAgent.SetDestination(hit.point);

                _targetFeedback.transform.position = new Vector3(hit.point.x,
                                                                hit.point.y + (transform.up * 0.02f).y,
                                                                hit.point.z);
                _targetFeedback.transform.forward = hit.normal;
            }
        }

        if (_targetFeedback != null)
            _targetFeedback.SetActive(!TargetReached());*/
        if (_targetFeedback != null)
        {
            _navMeshAgent.SetDestination(_targetFeedback.transform.position);
            if (TargetReached() == true || _targetFeedback == null)
            {
                this.GetComponent<Animator>().SetBool("Walk", false);
                if (fatto == false)
                    StartCoroutine(LanciaOggetto());
            }
            /* if (_navMeshAgent.isOnOffMeshLink)
             {
                 _navMeshAgent.autoTraverseOffMeshLink = false;
                 Debug.Log("navMeshLink");
             }*/
            else
            {
                this.GetComponent<Animator>().SetBool("Walk", true);
            }
        }

        
    }

    private bool TargetReached()
    {
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
                    return true;

        return false;
    }
    IEnumerator LanciaOggetto()
    {
        if (_targetFeedback.transform.position.y> 2.69)
        {
            
            yield return new WaitForSeconds(1f);
            this.GetComponent<Animator>().SetBool("LanciaOggetto", true);
            yield return new WaitForSeconds(3f);
            this.GetComponent<Animator>().SetBool("LanciaOggetto", false);
            this.GetComponent<Animator>().SetBool("LanciaSuRobot", true);
            //Debug.Log("jhvhjvjhvjh");
            _targetFeedback.GetComponent<Rigidbody>().AddForce(new Vector3(15f, 0f, 0f), ForceMode.Force);
            yield return new WaitForSeconds(2f);
           
            this.GetComponent<Animator>().SetBool("LanciaSuRobot", false);
            //fatto = true;
           
        }
        else
        {
            _targetFeedback = null;
        }
    }

}

