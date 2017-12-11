using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTagOffline : MonoBehaviour {

    /* TODO:
     * -Compress the addforce section of rotation into a single function to avoid repeated code.
     * -Clean up unused functions and debugs. 
     * -Add further protective code.
    */

    #region PrivateVariables

    private Rigidbody myRigidBody;
    private CapsuleCollider myCollider;

    #endregion

    #region PublicVariables

    public float desiredMovementSpeed;
    public float desiredTurningSpeed;
    public float desiredJumpForce;
    public float desiredClampValueForMovementMagnitude;
    public float desiredClampValueForRBVelocityMagnitude;
    public Animator myAnim;

    #endregion

    #region MyFunctions

    //Tracks movement input and stores the input into a vector
    private Vector3 MovementInput()
    {
        Vector3 inputToReturn;
        float horizontalTrack = Input.GetAxis("Joystick Horizontal");
        float verticalTrack = Input.GetAxis("Joystick Vertical");
        inputToReturn = new Vector3(horizontalTrack, 0f, verticalTrack);
        return inputToReturn;
    }

    //Takes in proccessed input and uses it to move the character via AddForce
    //Clamp was set to 0.2f originally
    private void MovementExecution(Vector3 vectorForMovement)
    {
        vectorForMovement.x = vectorForMovement.x * desiredMovementSpeed;
        vectorForMovement.z = vectorForMovement.z * desiredMovementSpeed;
        vectorForMovement.y = 0f;
        vectorForMovement = Vector3.ClampMagnitude(vectorForMovement, desiredClampValueForMovementMagnitude);
        //Debug.Log(vectorForMovement.magnitude);
        myRigidBody.AddForce(vectorForMovement, ForceMode.Impulse);
    }

    //Takes in the direction that the character is moving towards, and adds torque to rotate the character towards the direction of the vector
    private void RotationExecution(Vector3 vectorForStorage, Vector3 vectorForRotation)
    {
        if (Vector3.Dot(transform.forward, vectorForStorage) <= 0.99f && vectorForStorage != Vector3.zero)
        {
            vectorForRotation.x = vectorForRotation.x * desiredTurningSpeed;
            vectorForRotation.z = vectorForRotation.z * desiredTurningSpeed;
            myRigidBody.AddTorque(vectorForRotation, ForceMode.Impulse);
            //Debug.Log("gotta turn!");
        }

        else if (Vector3.Dot(transform.forward, vectorForStorage) >= 0.99f)
        {
            myRigidBody.angularVelocity = Vector3.zero;
            //Debug.Log("I can't stop help me");
        }

        else if (Vector3.Dot(transform.forward, vectorForStorage) >= 1 && vectorForStorage == new Vector3(-1, 0, -1) ||
            Vector3.Dot(transform.forward, vectorForStorage) >= 1 && vectorForStorage == new Vector3(1, 0, -1))
        {
            vectorForRotation.x = vectorForRotation.x * desiredTurningSpeed;
            vectorForRotation.z = vectorForRotation.z * desiredTurningSpeed;
            myRigidBody.AddTorque(vectorForRotation, ForceMode.Impulse);
        }

        else if (Vector3.Dot(transform.forward, vectorForStorage) >= 1 && vectorForStorage == new Vector3(-1, 0, 1) ||
            Vector3.Dot(transform.forward, vectorForStorage) >= 1 && vectorForStorage == new Vector3(1, 0, 1))
        {
            vectorForRotation.x = vectorForRotation.x * desiredTurningSpeed;
            vectorForRotation.z = vectorForRotation.z * desiredTurningSpeed;
            myRigidBody.AddTorque(vectorForRotation, ForceMode.Impulse);
        }

        else if (vectorForStorage == Vector3.zero)
        {
            myRigidBody.angularVelocity = Vector3.zero;
        }

        //Debug.Log(Vector3.Dot(transform.forward, vectorForStorage));
        //Debug.Log(vectorForStorage);
    }

    //Clamps the magnitude of the velocity vector of the rigid body attached to the player
    //Clamp was set to 35f originally
    private void ClampVelocityMagnitude()
    {
        if (myRigidBody.velocity.magnitude > desiredClampValueForRBVelocityMagnitude)
        {
            myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, desiredClampValueForRBVelocityMagnitude);
            //Debug.Log("HIT MAX");
        }
    }

    //Adds force to the player in the upwards direction after checking if they are grounded or not
    

    #endregion

    #region UnityFunctions

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        myAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 storageVector = MovementInput();
        //Vector3 movementStorageVector = CalculateMovementVector(storageVector);
        Vector3 rotationStorageVector = CalculateRotationVector(storageVector);
        MovementExecution(storageVector);
        RotationExecution(storageVector, rotationStorageVector);
        JumpExecution();
        ClampVelocityMagnitude();
        DebugUtility(storageVector);

        if(storageVector != Vector3.zero)
        {
            myAnim.SetBool("isRunning", true);
            myAnim.SetBool("isIdle", false);
        }
        else if(storageVector == Vector3.zero)
        {
            myAnim.SetBool("isRunning", false);
            myAnim.SetBool("isIdle", true);
        }
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

    private bool CheckJump()
    {
        float distanceToGround;
        distanceToGround = myCollider.bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
    private void JumpExecution()
    {
        if (CheckJump() && Input.GetAxis("Jump0") != 0)
        {
            //myAnim.SetTrigger("jump");
            myAnim.SetBool("isJump", true);
            AudioManager.instance.PlaySFX(GetComponent<AudioSource>(), 2, AudioManager.instance.bTSoundEffects);
            myRigidBody.AddForce(new Vector3(0f, desiredJumpForce, 0f), ForceMode.Impulse);
            Debug.Log("Jump0");
        }
        if(Input.GetAxis("Jump0") == 0)
        {
            myAnim.SetBool("isJump", false);
        }

    }
}
#endregion




