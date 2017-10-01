using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class BombTagCharacterController : MonoBehaviour
{
    #region PrivateVariables

    private Rigidbody myRigidBody;
    private Collider myCollider;

    #endregion

    #region PublicVariables

    public float desiredMovementSpeed;
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
        myRigidBody.AddForce(test, ForceMode.Force);
        Debug.DrawRay(gameObject.transform.position, test);
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
    }

    #endregion
}
