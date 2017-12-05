using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJumpControllerTwoOffline : MonoBehaviour {
    public Rigidbody myRigidBody;
    public CapsuleCollider myCollider;
    public float desiredJumpForce;

    private void JumpExecution()
    {
        if (CheckJump() && Input.GetAxis("Jump1") != 0)
        {


            myRigidBody.AddForce(new Vector3(0f, desiredJumpForce, 0f), ForceMode.Impulse);
            Debug.Log("Jump1");
        }
    }

    private bool CheckJump()
    {
        float distanceToGround;
        distanceToGround = myCollider.bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    private void CrouchExecution()
    {


        if (Input.GetAxis("Crouch1") != 0)
        {
            myCollider.height = 1.5f;
        }
        else if (Input.GetAxis("Crouch1") == 0)
        {
            myCollider.height = 2f;
        }




       // Debug.Log("Crouch1");

    }

    private void Update()
    {
        CrouchExecution();
        JumpExecution();
        myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 12);
        //Debug.Log(myRigidBody.velocity.magnitude);
    }

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
    }

}
