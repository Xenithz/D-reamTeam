using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTCharacterController : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public CapsuleCollider myCollider;
    public float desiredJumpForce;
    public Animator myAnim;
    public float colliderLow;
    public float colliderHigh;

    private void JumpExecution()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckJump())
        {
            myAnim.SetBool("isJump", true);
            myRigidBody.AddForce(new Vector3(0f, desiredJumpForce, 0f), ForceMode.Impulse);
            //Debug.Log("Jump");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            myAnim.SetBool("isCrouch", true);
            myCollider.height = colliderLow;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            myAnim.SetBool("isCrouch", false);
            myCollider.height = colliderHigh;
        }
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
        myAnim = GetComponent<Animator>();
        colliderLow = 1;
        colliderHigh = 1.1f;
    }

}
