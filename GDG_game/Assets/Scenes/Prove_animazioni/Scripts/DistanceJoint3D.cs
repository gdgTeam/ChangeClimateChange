using UnityEngine;


public class DistanceJoint3D : MonoBehaviour
{

    public Transform ConnectedRigidbody;
    public bool DetermineDistanceOnStart = false;
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
        /*Debug.Log("start");
        if ( ConnectedRigidbody != null)
            if(Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position)>7f)
            {
                Debug.Log("minore");

                Distance = Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position)-2f;
            }
        else
            {
                Debug.Log("maggiore");
                Distance = 6;
            }*/
           
    }

    private void OnEnable()
    {
        if (ConnectedRigidbody != null)
        {

            if (Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position) > 5f)
            {
                Debug.Log("maggiore");

                Distance = Vector3.Distance(Rigidbody.position, ConnectedRigidbody.position)-1f;
            }
            else
            {
                Debug.Log("minore");
                Distance =4f;
            }
        }
    }
    void FixedUpdate()
    {

        Debug.Log(ConnectedRigidbody);

        var connection = Rigidbody.position - ConnectedRigidbody.position;
        var distanceDiscrepancy = Distance - connection.magnitude;

        Rigidbody.position += distanceDiscrepancy * connection.normalized;

        var velocityTarget = connection + (Rigidbody.velocity + Physics.gravity * Spring);
        var projectOnConnection = Vector3.Project(velocityTarget, connection);
        Rigidbody.velocity = (velocityTarget - projectOnConnection) / (1 + Damper * Time.fixedDeltaTime);


    }
}
