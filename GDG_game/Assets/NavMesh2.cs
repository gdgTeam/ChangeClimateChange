using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMesh2 : MonoBehaviour
{
    //[SerializeField] private Camera _camera;
    public GameObject _targetFeedback;
    
    private NavMeshAgent _navMeshAgent;
    private bool fatto = false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _targetFeedback = GameObject.FindGameObjectWithTag("Player");
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
        }*/

      

        if (_targetFeedback != null)
        {
            Vector3 dest = new Vector3(_targetFeedback.transform.position.x - 2.4f, _targetFeedback.transform.position.y, _targetFeedback.transform.position.z);
            // Debug.Log(_targetFeedback + ":" + TargetReached() + count);
            _navMeshAgent.SetDestination(dest);
            if (TargetReached() == true)
            {
                Debug.Log("kbb");
                this.GetComponent<Animator>().SetBool("Walk", false);
               
            }

            else
            {
                Debug.Log("kbb");
                this.GetComponent<Animator>().SetBool("Walk", true);
            }


        }

        /* if(fatto==true && _targetFeedback.name == "secondo")
         {
           //  Debug.Log("bhbhjbjh");
             this.GetComponent<NavMeshAgent>().enabled = false;
         }*/


    }

    private bool TargetReached()
    {
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }

        return false;
    }
   
 }

  


