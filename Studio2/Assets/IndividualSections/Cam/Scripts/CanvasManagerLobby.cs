using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasManagerLobby : MonoBehaviour {
    public GameObject LobbyCanvas;
    public GameObject RoomCanvas; 
	// Use this for initialization
	void Start () {

        LobbyCanvas.SetActive(false);
        RoomCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnJoinedLobby()
    {
        LobbyCanvas.SetActive(true);
    }

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom("Room 1" );
        LobbyCanvas.SetActive(false);
        RoomCanvas.SetActive(true);

    }

    public virtual void OnJoinedRoom()
    {
        LobbyCanvas.SetActive(false);
        RoomCanvas.SetActive(true);

    }

  
}

    
