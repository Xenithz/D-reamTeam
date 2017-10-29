using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBKnockBackTest : MonoBehaviour
{
    Rigidbody myRigidBody;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        myRigidBody.AddForce(Vector3.forward * 2);
        Debug.DrawRay(transform.position, myRigidBody.velocity, Color.red);
    }
}
