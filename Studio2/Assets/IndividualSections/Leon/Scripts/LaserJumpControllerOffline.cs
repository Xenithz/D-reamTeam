using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJumpControllerOffline : MonoBehaviour {

    public Rigidbody myRigidBody;
    public CapsuleCollider myCollider;
    public float desiredJumpForce;

    private void JumpExecution()
    {
        if ( CheckJump())
        {
        
            float desiredJumpForced = Input.GetAxis("Jump");
            myRigidBody.AddForce(new Vector3(0f, desiredJumpForced * desiredJumpForce, 0f), ForceMode.Impulse);
            Debug.Log("Jump");
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
         float crouchHeight=Input.GetAxis("Crouch");





        myCollider.height = crouchHeight;
        Debug.Log("Crouch");
       
    }

    private void Update()
    {
        CrouchExecution();
        JumpExecution();
    }

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
    }

}
