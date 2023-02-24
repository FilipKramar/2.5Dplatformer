using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1f;
        rigidbodyComponent = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        if (IsFacingRight())
        {
            rigidbodyComponent.velocity = new Vector3(moveSpeed, 0f);


        }
        else
            rigidbodyComponent.velocity = new Vector3(-moveSpeed, 0f);
    }
    bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer!= 6)
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

}
