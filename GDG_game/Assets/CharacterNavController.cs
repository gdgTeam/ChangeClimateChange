using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterNavController : MonoBehaviour
{
    //[SerializeField] private Camera _camera;
     public GameObject _targetFeedback;
    public GameObject _targetFeedback2;
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
        }*/

        if (_targetFeedback == null)
           Changebox();
      
        if (_targetFeedback != null)
        {
           // Debug.Log(_targetFeedback + ":" + TargetReached() + count);
            _navMeshAgent.SetDestination(_targetFeedback.transform.position);
            if (TargetReached() == true )
            {
                    this.GetComponent<Animator>().SetBool("Walk", false);
                    if (fatto == false)
                        StartCoroutine(LanciaOggetto(_targetFeedback));
               
            }
           
            else
            {
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
    IEnumerator LanciaOggetto(GameObject target)
    {
        if (target!= null && target.transform.position.x< 84 && fatto==false)
        {
            Debug.Log(target);
            yield return new WaitForSeconds(1f);
            this.GetComponent<Animator>().SetBool("LanciaOggetto", true);
            yield return new WaitForSeconds(3f);
            
            this.GetComponent<Animator>().SetBool("LanciaOggetto", false);
            this.GetComponent<Animator>().SetBool("LanciaSuRobot", true);
            target.transform.Translate(Vector3.right * 2f * Time.deltaTime);
        
            // target.GetComponent<Rigidbody>().AddForce(new Vector3(7f, 0f, 0f), ForceMode.Force);
            yield return new WaitForSeconds(1f);
            
            this.GetComponent<Animator>().SetBool("LanciaSuRobot", false);

            fatto = true;
           // if(_targetFeedback.name=="primo")
            _targetFeedback = null;

        }
       
    }

    private void Changebox()
    {

        fatto = false;

        _targetFeedback = _targetFeedback2;
        
       // _targetFeedback2 = null;
        
    }

}

