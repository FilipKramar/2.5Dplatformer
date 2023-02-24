using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematicplatforms : MonoBehaviour
{
    private Rigidbody rigidbodyComponent;
    [SerializeField] private Transform InitiaLPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }
   
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            rigidbodyComponent.isKinematic = false;
        rigidbodyComponent.velocity = new Vector3(0, -3, 0);

        
            

    }
     
}
