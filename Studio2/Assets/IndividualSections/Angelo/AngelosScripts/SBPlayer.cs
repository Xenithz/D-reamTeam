using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBPlayer : MonoBehaviour
{
    public SumoBallCharacterController myController;
    public int pushBackValue;

    private void Awake()
    {
        myController = GetComponent<SumoBallCharacterController>();
        pushBackValue = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Rigidbody collidedRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            if (collidedRigidBody.velocity.magnitude > myController.myRigidBody.velocity.magnitude)
            {
                myController.myRigidBody.AddForce(myController.transform.forward * -pushBackValue, ForceMode.Impulse);
                Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
                Debug.Log("they win");
            }

            if (collidedRigidBody.velocity.magnitude < myController.myRigidBody.velocity.magnitude)
            {
                collidedRigidBody.AddForce(collidedRigidBody.transform.forward * -pushBackValue, ForceMode.Impulse);
                Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
                Debug.Log("I win");
            }

            if (collidedRigidBody.velocity.magnitude == myController.myRigidBody.velocity.magnitude)
            {
                int myRandom = Random.Range(1, 2);

                if (myRandom == 1)
                {
                    myController.myRigidBody.AddForce(myController.transform.forward * -pushBackValue, ForceMode.Impulse);
                    Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
                    Debug.Log("they win");
                }

                if (myRandom == 2)
                {
                    collidedRigidBody.AddForce(collidedRigidBody.transform.forward * -pushBackValue, ForceMode.Impulse);
                    Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
                    Debug.Log("I win");
                }
            }


            //Debug.Log(collision.relativeVelocity.magnitude);
            //Debug.DrawLine(collision.gameObject.transform.position, collision.relativeVelocity,Color.blue);

        }
    }
}
