using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : Photon.MonoBehaviour, IPunObservable
{


    bool hasPushed = false;
    public static int playersReady = 0; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

   
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
    public void PlayerStarted()
    {
        photonView.RPC("OnStart", PhotonTargets.AllBufferedViaServer);
    }
    [PunRPC]
    public void OnStart ()
    {


        PhotonNetwork.LoadLevel(6);


    }

    
}
