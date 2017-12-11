using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJumpControllerTwoOffline : MonoBehaviour {

    public Rigidbody myRigidBody;
    public CapsuleCollider myCollider;
    public float desiredJumpForce;
    public Animator myAnim;
    public float defaultY;
    public float colliderLow;
    public float colliderHigh;

    private void JumpExecution()
    {
        if (CheckJump() && Input.GetAxis("Jump1") != 0)
        {

            myAnim.SetBool("isJump", true);
            myRigidBody.AddForce(new Vector3(0f, desiredJumpForce, 0f), ForceMode.Impulse);
            Debug.Log("Jump1");
        }

        if(Input.GetAxis("Jump1") == 0)
        {
            myAnim.SetBool("isJump", false);
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


        if (Input.GetAxis("Crouch") != 0)
        {
            myAnim.SetBool("isCrouch", true);
            myCollider.height = colliderLow;
        }
        else if (Input.GetAxis("Crouch") == 0)
        {
            myAnim.SetBool("isCrouch", false);
            myCollider.height = colliderHigh;
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
        myAnim = GetComponent<Animator>();
        defaultY = transform.position.y;
        colliderLow = 1;
        colliderHigh = 1.1f;
    }

}
