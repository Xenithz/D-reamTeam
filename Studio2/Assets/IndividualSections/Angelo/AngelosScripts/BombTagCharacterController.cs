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

    private void MovementExecution(Vector3 vectorForMovement)
    {
        Vector3 movementVector = vectorForMovement;
        movementVector.x = movementVector.x * desiredMovementSpeed;
        movementVector.z = movementVector.z * desiredMovementSpeed;
        movementVector.y = 0f;
        myRigidBody.AddForce(movementVector, ForceMode.Impulse);
    }

    private void RotationExecution(Vector3 inputForRotation)
    {
        Vector3 test2 = gameObject.transform.up * inputForRotation.x;
        test2.x = test2.x * desiredTurningSpeed;
        myRigidBody.AddTorque(test2, ForceMode.VelocityChange);
    }

    private void JumpExecution()
    {
        if (myRigidBody.velocity.y == 0)
        {
            Debug.Log("LL");
        }
    }

    #endregion

    #region UnityFunctions

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        Vector3 storageVector = MovementInput();
        Vector3 movementStorageVector = CalculateMovementVector(storageVector);
        MovementExecution(movementStorageVector);
        DebugUtility(storageVector);
    }

    #endregion

    #region UtilityFunctions

    private void DebugUtility(Vector3 inputForMovement)
    {
        Vector3 movementVector = CalculateMovementVector(inputForMovement);
        Debug.DrawRay(gameObject.transform.position, movementVector);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward);
    }

    private Vector3 CalculateMovementVector(Vector3 input)
    {
        Vector3 vectorForMovement = gameObject.transform.forward * input.z + gameObject.transform.right * input.x;
        return vectorForMovement;
    }
    #endregion
}
