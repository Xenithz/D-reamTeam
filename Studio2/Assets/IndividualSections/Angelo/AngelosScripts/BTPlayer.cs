using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTPlayerState
{
    hasBomb,
    noBomb
}

public class BTPlayer : MonoBehaviour
{
    public BTPlayerState currentPlayerState;
    public BTBomb myBomb;

    private void Awake()
    {
        currentPlayerState = BTPlayerState.noBomb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BTPlayer>() != null)
        {
            BTPlayer collidedBT = collision.gameObject.GetComponent<BTPlayer>();
            Debug.Log("check 1");

            Debug.Log(currentPlayerState + " " + collidedBT.currentPlayerState);

            if(collidedBT.currentPlayerState == BTPlayerState.noBomb && currentPlayerState == BTPlayerState.hasBomb)
            {
                Debug.Log("check 2");
                myBomb.SetBombOwner(collision.gameObject);
                currentPlayerState = BTPlayerState.noBomb;
            }
        }

        else if(collision.gameObject.GetComponent<BTPlayer>() == null)
        {
            Debug.Log("hdgfhkfakj");
        }
    }
}
