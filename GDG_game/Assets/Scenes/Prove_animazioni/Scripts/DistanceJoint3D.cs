using UnityEngine;


public class DistanceJoint3D : MonoBehaviour
{

    public Transform ConnectedRigidbody;
    public bool DetermineDistanceOnStart = true;
    public float Distance;
    public float Spring = 0.1f;
    public float Damper = 5f;
   

    protected Rigidbody Rigidbody;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

    }

    void Start()
    {
        
        if (DetermineDistanceOnStart && ConnectedRigidbody != null)
            if(Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position)>4.5f)
            {
                Debug.Log("magg4.5: "+ Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position));
                Distance = Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position)-1f;
            }
        else
            {
                Debug.Log("min4.5: " + Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position));
                Distance = 5;
            }
           
    }

    void FixedUpdate()
    {

        var connection = Rigidbody.position - ConnectedRigidbody.position;
        var distanceDiscrepancy = Distance - connection.magnitude;

        Rigidbody.position += distanceDiscrepancy * connection.normalized;

        var velocityTarget = connection + (Rigidbody.velocity + Physics.gravity * Spring);
        var projectOnConnection = Vector3.Project(velocityTarget, connection);
        Rigidbody.velocity = (velocityTarget - projectOnConnection) / (1 + Damper * Time.fixedDeltaTime);


    }
}
