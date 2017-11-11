using System.Collections;
using System.Collections.Generic;
using Photon; 
using UnityEngine;

public class SBPlayer : Photon.MonoBehaviour, IPunObservable
{
    public SumoBallCharacterController myController;
    public int pushBackValue;

    private void Awake()
    {
        myController = GetComponent<SumoBallCharacterController>();
        pushBackValue = 15;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() != null)
        {

            photonView.RPC("KnockBack", PhotonTargets.All, collision.gameObject.name);

           
        }

       


    //Debug.Log(collision.relativeVelocity.magnitude);
    //Debug.DrawLine(collision.gameObject.transform.position, collision.relativeVelocity,Color.blue);



       
}
    [PunRPC]
    public void KnockBack(string name)
    {
        Debug.Log("colliding lol");
        GameObject collidedGameObject = GameObject.Find(name);

        Rigidbody collidedRigidBody = collidedGameObject.GetComponent<Rigidbody>();


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


    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
