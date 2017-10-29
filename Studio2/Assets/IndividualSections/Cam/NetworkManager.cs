using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI;
using UnityEngine;

public class NetworkManager : PunBehaviour {

    [SerializeField]private Text connectionText; 

	// Use this for initialization
	void Start () {

        PhotonNetwork.ConnectUsingSettings("0.1");
		
	}
	

    public virtual void OnJoinedLobby()
    {
        Debug.Log("connected to master");
    }
	// Update is called once per frame
	void Update () {

        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
		
	}
}
