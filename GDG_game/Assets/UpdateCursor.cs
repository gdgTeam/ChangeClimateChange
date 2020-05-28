using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCursor : MonoBehaviour
{
    MousePointer mouse;
    public Color rosso;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            if (r.gameObject.transform.parent != null)
            {
                r.enabled = false;

            }

        }
        mouse = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MousePointer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnMouseEnter()
    {
        Debug.Log("Enter");

        mouse.setGrab();
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            if (r.gameObject.transform.parent != null)
            {
                r.enabled = true;
                
            }
           
        }

    }
    private void OnMouseExit()
    {
        StartCoroutine(Disappear());
       
    }
    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f);
        mouse.setMouse();
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            if (r.gameObject.transform.parent != null)
                r.enabled = false;

        }
    }

}
