using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBPlayerOffline : MonoBehaviour
{
    public SBControl myController;
    public int pushBackValue;
    public float currentTimeTillKnockback;
    public float timeTillKnockback;
    public bool goNow;

    private void Awake()
    {
        myController = GetComponent<SBControl>();
        pushBackValue = 5;
        currentTimeTillKnockback = timeTillKnockback;
        goNow = true;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "floor")
        {
            this.gameObject.SetActive(false);
        }

        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            if (goNow == true)
            {
                KnockBack(collision.gameObject.name);
            }
            else if (goNow == false)
            {
                Debug.Log("niceTry");
            }
        }
    }

    private void Update()
    {
        if (goNow == false)
        {
            TimeTickDown();
        }
    }

    public void KnockBack(string name)
    {
        GameObject collidedGameObject = GameObject.Find(name);
        Rigidbody collidedRigidBody = collidedGameObject.GetComponent<Rigidbody>();

        if (collidedRigidBody.velocity.magnitude < myController.myRigidBody.velocity.magnitude)
        {
            Vector3 direction = collidedRigidBody.GetComponent<SumoBallCharacterController>().myHeading;
            Vector3 myDirection = GetComponent<SumoBallCharacterController>().myHeading;

            if (direction != Vector3.zero)
            {
                AudioManager.instance.PlaySFX(GetComponent<AudioSource>(), 0, 0, 0.23f, AudioManager.instance.sBSoundEffects);
                collidedRigidBody.AddForce(direction.normalized * -pushBackValue, ForceMode.Impulse);
                myController.myRigidBody.AddForce(-direction.normalized * (pushBackValue - 1), ForceMode.Impulse);
                goNow = false;
                Debug.Log("I win");
            }

            else if (direction == Vector3.zero)
            {
                AudioManager.instance.PlaySFX(GetComponent<AudioSource>(), 0, 0, 0.23f, AudioManager.instance.sBSoundEffects);
                collidedRigidBody.AddForce((collidedRigidBody.transform.position + myDirection).normalized * pushBackValue, ForceMode.Impulse);
                goNow = false;
                Debug.Log("I win");
            }
        }
    }

    public void TimeTickDown()
    {
        currentTimeTillKnockback -= Time.deltaTime;
        if (currentTimeTillKnockback <= 0)
        {
            goNow = true;
            currentTimeTillKnockback = timeTillKnockback;
        }
    }
}
