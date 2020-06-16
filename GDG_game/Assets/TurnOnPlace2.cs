using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPlace2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GiraSulPosto());
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Animator>().SetBool("Walk", false);
    }
    private IEnumerator GiraSulPosto()
    {

        this.GetComponent<Animator>().SetBool("OnPlace2", true);
        yield return new WaitForSeconds(0.6f);
        this.GetComponent<Animator>().SetBool("OnPlace2", false);
        yield return new WaitForSeconds(4f);
        StartCoroutine(GiraSulPosto());
    }
}