using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBControl : MonoBehaviour
{
    #region PublicVariables

    public Rigidbody myRigidBody;
    public float desiredMovementSpeed;
    public float desiredTurningSpeed;
    public float desiredJumpForce;
    public float desiredClampValueForMovementMagnitude;
    public float desiredClampValueForRBVelocityMagnitude;

    public Vector3 myHeading;

    public SphereCollider myCollider;

    #endregion
}
