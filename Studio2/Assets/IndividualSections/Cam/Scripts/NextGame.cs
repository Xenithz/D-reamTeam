using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGame : Photon.MonoBehaviour, IPunObservable {

	// Use this for initialization
	void Start () {
	
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void OnSumoPress()
    {
        photonView.RPC("OnClickSumoNext", PhotonTargets.AllBufferedViaServer);
    }

    public void OnLaserTagPress()
    {
        photonView.RPC("OnClickLaserNext", PhotonTargets.AllBufferedViaServer);
    }
    [PunRPC]
    public void OnClickSumoNext()
    {

        PhotonNetwork.LoadLevel(7);
    }

    [PunRPC]
    public void OnClickLaserNext()
    {

        PhotonNetwork.LoadLevel(8);

    }
}
