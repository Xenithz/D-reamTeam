using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;

public class BTNetwork : Photon.MonoBehaviour {
    BombTagCharacterController controlScript;



    void Awake()
    {

        controlScript = GetComponent<BombTagCharacterController>();
        if (photonView.isMine)
        {
            //MINE: local player, simply enable the local scripts
            controlScript.enabled = true;
        }
        else
        {

            controlScript.enabled = true;
        }
        gameObject.name = gameObject.name + photonView.viewID;

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //We own this player: send the others our data
            //stream.SendNext((int)controllerScript._characterState);
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            //Network player, receive data
            //controllerScript._characterState = (CharacterState)(int)stream.ReceiveNext();
            //correctPlayerPos = (Vector3)stream.ReceiveNext();
            //correctPlayerRot = (Quaternion)stream.ReceiveNext();

            // avoids lerping the character from "center" to the "current" position when this client joins
            // if (firstTake)
            //{
            // firstTake = false;
            // this.transform.position = correctPlayerPos;
            // transform.rotation = correctPlayerRot;
        //}

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
