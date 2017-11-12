using System.Collections;
using System.Collections.Generic;
using Photon; 
using UnityEngine;

public class SBPlayer : Photon.MonoBehaviour, IPunObservable
{
    public SumoBallCharacterController myController;
    public int pushBackValue;
    public float currentTimeTillKnockback;
    public float timeTillKnockback;
    public bool goNow;

    private void Awake()
    {
        myController = GetComponent<SumoBallCharacterController>();
        pushBackValue = 15;
        currentTimeTillKnockback = timeTillKnockback;
        goNow = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            if(goNow == true)
            {
                photonView.RPC("KnockBack", PhotonTargets.All, collision.gameObject.name);
                KnockBack(collision.gameObject.name);
            }
            else if(goNow == false)
            {
                Debug.Log("niceTry");
            }
        }
    //Debug.Log(collision.relativeVelocity.magnitude);
    //Debug.DrawLine(collision.gameObject.transform.position, collision.relativeVelocity,Color.blue);   
    }

    private void Update()
    {
        if(goNow == false)
        {
            TimeTickDown();
        }
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
            goNow = false;
            Debug.Log("they win");
        }

        if (collidedRigidBody.velocity.magnitude < myController.myRigidBody.velocity.magnitude)
        {
            collidedRigidBody.AddForce(collidedRigidBody.transform.forward * -pushBackValue, ForceMode.Impulse);
            Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
            goNow = false;
            Debug.Log("I win");
        }

        if (collidedRigidBody.velocity.magnitude == myController.myRigidBody.velocity.magnitude)
        {
            int myRandom = Random.Range(1, 2);

            if (myRandom == 1)
            {
                myController.myRigidBody.AddForce(myController.transform.forward * -pushBackValue, ForceMode.Impulse);
                Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
                goNow = false;
                Debug.Log("they win");
            }

            if (myRandom == 2)
            {
                collidedRigidBody.AddForce(collidedRigidBody.transform.forward * -pushBackValue, ForceMode.Impulse);
                Debug.Log(myController.myRigidBody.velocity.magnitude + " " + collidedRigidBody.velocity.magnitude);
                goNow = false;
                Debug.Log("I win");
            }
        }


    }

    public void TimeTickDown()
    {
        currentTimeTillKnockback -= Time.deltaTime;
        if(currentTimeTillKnockback <= 0)
        {
            goNow = true;
            currentTimeTillKnockback = timeTillKnockback;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
