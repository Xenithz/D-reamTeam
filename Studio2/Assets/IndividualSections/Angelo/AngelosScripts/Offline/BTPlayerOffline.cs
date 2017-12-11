using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPlayerOffline : MonoBehaviour
{
    public BTPlayerState currentPlayerState;
    public BTBombOffline myBomb;

    private void Awake()
    {
        currentPlayerState = BTPlayerState.noBomb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BTPlayerOffline>() != null)
        {
            BTPlayerOffline collidedBT = collision.gameObject.GetComponent<BTPlayerOffline>();
            Debug.Log("check 1");

            Debug.Log(currentPlayerState + " " + collidedBT.currentPlayerState);

            if (collidedBT.currentPlayerState == BTPlayerState.noBomb && currentPlayerState == BTPlayerState.hasBomb && myBomb.bombIsAbleToSwitch == true)
            {
                Debug.Log("check 2");
                myBomb.SetBombOwner(collision.gameObject.name);
                SetState();
            }
        }

        else if (collision.gameObject.GetComponent<BTPlayer>() == null)
        {
            Debug.Log("hdgfhkfakj");
        }
    }

    public void SetState()
    {
        currentPlayerState = BTPlayerState.noBomb;
    }
}
