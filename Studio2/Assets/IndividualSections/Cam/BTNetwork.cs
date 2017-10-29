using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine;

public class BTNetwork : Photon.MonoBehaviour {


    BombTagCharacterController controlScript;
    public NetworkManager Instance;


    void Awake()
    {
        Instance = GetComponent<NetworkManager>();
        controlScript = GetComponent<BombTagCharacterController>();
        if (photonView.isMine)
        {
            //MINE: local player, simply enable the local scripts
            controlScript.enabled = true;
        }
        else
        {

            controlScript.enabled = false;
        }
            gameObject.name = gameObject.name + photonView.viewID;

    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {

            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }

        else
        {

            foreach(GameObject player in Instance.allPlayers )
            {
                player.transform.position = (Vector3) stream.ReceiveNext();
                player.transform.rotation = (Quaternion)stream.ReceiveNext();
            }

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
