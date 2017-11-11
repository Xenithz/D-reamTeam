using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour {
    GameObject localPlayer;
    string localPlayerName;
    public Text playerName;

    // Use this for initialization
    void Start () {

        localPlayer = GameObject.Find("PlayerInfo");
        print("Connecting to server");
        PhotonNetwork.ConnectUsingSettings("0.1");
		
	}

    void OnConnectedToMaster()
    {
        print("Connected To Master");
       
    }
	

    void OnJoinedLobby ()
    {
        print("joined lobby");
        PhotonNetwork.playerName = localPlayer.GetComponent<LocalPlayerInfo>().localPlayerName;
        playerName.text = localPlayer.GetComponent<LocalPlayerInfo>().localPlayerName;
    }
	// Update is called once per frame
	void Update () {

        
		
	}
}
