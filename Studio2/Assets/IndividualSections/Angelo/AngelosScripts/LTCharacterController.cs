using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTCharacterController : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public CapsuleCollider myCollider;
    public float desiredJumpForce;

    private void JumpExecution()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckJump())
        {
            myRigidBody.AddForce(new Vector3(0f, desiredJumpForce, 0f), ForceMode.Impulse);
            //Debug.Log("Jump");
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
            myCollider.height = 1.5f;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            myCollider.height = 2f;
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
    }

}
