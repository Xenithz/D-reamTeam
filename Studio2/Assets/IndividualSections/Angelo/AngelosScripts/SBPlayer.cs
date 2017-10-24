using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBPlayer : MonoBehaviour
{
    public SumoBallCharacterController myController;

    private void Awake()
    {
        myController = GetComponent<SumoBallCharacterController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<SumoBallCharacterController>() != null)
        {
            SumoBallCharacterController collidedController = collision.gameObject.GetComponent<SumoBallCharacterController>();

            if(collidedController.myRigidBody.velocity.magnitude > myController.myRigidBody.velocity.magnitude)
            {
                myController.myRigidBody.AddForce(collidedController.myRigidBody.velocity - myController.myRigidBody.velocity, ForceMode.Impulse);
            }

            else if (collidedController.myRigidBody.velocity.magnitude < myController.myRigidBody.velocity.magnitude)
            {
                collidedController.myRigidBody.AddForce(myController.myRigidBody.velocity - collidedController.myRigidBody.velocity, ForceMode.Impulse);
            }

            else if (collidedController.myRigidBody.velocity.magnitude == myController.myRigidBody.velocity.magnitude)
            {
                int myRandom = Random.Range(1, 2);

                if(myRandom == 1)
                {
                    collidedController.myRigidBody.AddForce(myController.myRigidBody.velocity - collidedController.myRigidBody.velocity, ForceMode.Impulse);
                }

                else if(myRandom == 2)
                {
                    myController.myRigidBody.AddForce(collidedController.myRigidBody.velocity - myController.myRigidBody.velocity, ForceMode.Impulse);
                }
            }
        }
    }
}
