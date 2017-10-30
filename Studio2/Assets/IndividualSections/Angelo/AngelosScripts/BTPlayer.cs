using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTPlayerState
{
    hasBomb,
    noBomb
}

public class BTPlayer : Photon.MonoBehaviour, IPunObservable
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

            if(collidedBT.currentPlayerState == BTPlayerState.noBomb && currentPlayerState == BTPlayerState.hasBomb && myBomb.bombIsAbleToSwitch == true)
            {
                Debug.Log("check 2");
                //myBomb.SetBombOwner(collision.gameObject);
                NetworkManager.Instance.photonView.RPC("SetBombOwner", PhotonTargets.All, collision.gameObject.name);
                // this.currentPlayerState = BTPlayerState.noBomb;
                photonView.RPC("SetState", PhotonTargets.All);
            }
        }

        else if(collision.gameObject.GetComponent<BTPlayer>() == null)
        {
            Debug.Log("hdgfhkfakj");
        }
    }

    [PunRPC]
    public void SetState ()
    {
        currentPlayerState = BTPlayerState.noBomb;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
