using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class BombTagCharacterController : MonoBehaviour
{
    #region PrivateVariables

    private Rigidbody myRigidBody;

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
        vectorForMovement.x = vectorForMovement.x * desiredMovementSpeed;
        vectorForMovement.z = vectorForMovement.z * desiredMovementSpeed;
        vectorForMovement.y = 0f;
        myRigidBody.AddForce(vectorForMovement, ForceMode.Impulse);
    }

    private void RotationExecution(Vector3 vectorForStorage, Vector3 vectorForRotation)
    {
        if(Vector3.Dot(transform.forward, vectorForStorage) <= 0.99f && vectorForStorage != Vector3.zero)
        {
            vectorForRotation.x = vectorForRotation.x * desiredTurningSpeed;
            vectorForRotation.z = vectorForRotation.z * desiredTurningSpeed;
            myRigidBody.AddTorque(vectorForRotation, ForceMode.Acceleration);
            Debug.Log("gotta turn!");
        }

        else if(Vector3.Dot(transform.forward,vectorForStorage) >= 0.99f)
        {
            myRigidBody.angularVelocity = Vector3.zero;
            Debug.Log("I can't stop help me");
        }
        
        else if(vectorForStorage == Vector3.zero)
        {
            myRigidBody.angularVelocity = Vector3.zero;
        }

        Debug.Log(Vector3.Dot(transform.forward, vectorForStorage));
    }

    #endregion

    #region UnityFunctions

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 storageVector = MovementInput();
        //Vector3 movementStorageVector = CalculateMovementVector(storageVector);
        Vector3 rotationStorageVector = CalculateRotationVector(storageVector);
        MovementExecution(storageVector);
        RotationExecution(storageVector, rotationStorageVector);
        DebugUtility(storageVector);
    }

    #endregion

    #region UtilityFunctions

    private void DebugUtility(Vector3 input)
    {
        //Vector3 movementVector = CalculateMovementVector(input);
        Debug.DrawRay(gameObject.transform.position, input * 3, Color.blue);
        //Debug.DrawRay(gameObject.transform.position, movementVector * 2, Color.green);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward, Color.white);
        //Debug.Log(myRigidBody.angularVelocity);
    }

    //private Vector3 CalculateMovementVector(Vector3 input)
    //{
    //    Vector3 vectorForMovement = gameObject.transform.forward * input.z + gameObject.transform.right * input.x;
    //    return vectorForMovement;
    //}

    private Vector3 CalculateRotationVector(Vector3 input)
    {
        Vector3 vectorForRotation = gameObject.transform.up * input.z + gameObject.transform.up * input.x;
        return vectorForRotation;
    }
    #endregion
}
