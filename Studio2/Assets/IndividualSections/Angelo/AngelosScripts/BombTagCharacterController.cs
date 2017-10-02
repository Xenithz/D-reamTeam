using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class BombTagCharacterController : MonoBehaviour
{
    #region PrivateVariables

    private Rigidbody myRigidBody;
    private Collider myCollider;

    #endregion

    #region PublicVariables

    public float desiredMovementSpeed;
    public float desiredTurningSpeed;
    public float desiredJumpForce;
    #endregion

    #region MyFunctions

    private Vector3 MovementInput()
    {
        Vector3 inputToReturn;
        float horizontalTrack = Input.GetAxis("Horizontal");
        float verticalTrack = Input.GetAxis("Vertical");
        inputToReturn = new Vector3(horizontalTrack, 0f, verticalTrack);
        return inputToReturn;
    }

    private void MovementExecution(Vector3 inputForMovement)
    {
        Vector3 test = gameObject.transform.forward * inputForMovement.z + gameObject.transform.right * inputForMovement.x;
        test.x = test.x * desiredMovementSpeed;
        test.z = test.z * desiredMovementSpeed;
        test.y = 0f;
        myRigidBody.AddForce(test, ForceMode.Impulse);
    }

    private void RotationExecution(Vector3 inputForRotation)
    {
        Vector3 test2 = gameObject.transform.up * inputForRotation.x;
        test2.x = test2.x * desiredTurningSpeed;
        myRigidBody.AddTorque(test2, ForceMode.VelocityChange);
    }

    private void JumpExecution()
    {
        if(myRigidBody.velocity.y == 0)
        {
            Debug.Log("LL");
        }
    }

    private void DebugUtility(Vector3 inputForMovement)
    {
        Vector3 test = gameObject.transform.forward * inputForMovement.z + gameObject.transform.right * inputForMovement.x;
        Debug.DrawRay(gameObject.transform.position, test);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward);
    }

    #endregion

    #region UnityFunctions

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 storageVector = MovementInput();
        MovementExecution(storageVector);
        RotationExecution(storageVector);
        DebugUtility(storageVector);
    }

    #endregion
}
