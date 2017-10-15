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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BTPlayer>() != null)
        {
            BTPlayer collidedBT = GetComponent<BTPlayer>();

            if(collidedBT.currentPlayerState == BTPlayerState.noBomb && this.currentPlayerState == BTPlayerState.hasBomb)
            {
                myBomb.SetBombOwner(collision.gameObject);
            }
        }
    }
}
