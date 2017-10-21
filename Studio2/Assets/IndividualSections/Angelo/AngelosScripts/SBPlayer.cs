using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBPlayer : MonoBehaviour
{
    public SumoBallCharacterController myController;

    private void Awake()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<SumoBallCharacterController>() != null)
        {
            SumoBallCharacterController collidedController = collision.gameObject.GetComponent<SumoBallCharacterController>();

            if(collidedController.myRigidBody.velocity.magnitude > myController.myRigidBody.velocity.magnitude)
            {

            }

            else if (collidedController.myRigidBody.velocity.magnitude < myController.myRigidBody.velocity.magnitude)
            {

            }

            else if (collidedController.myRigidBody.velocity.magnitude == myController.myRigidBody.velocity.magnitude)
            {
                int myRandom = Random.Range(1, 2);

                if(myRandom == 1)
                {

                }

                else if(myRandom == 2)
                {

                }
            }
        }
    }
}
