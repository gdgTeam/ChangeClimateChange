using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyConstraints : MonoBehaviour
{
    private RigidbodyConstraints rigidbodyConstraints;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
       
        //rigidbodyConstraints.FreezePositionX = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
