using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LobbyNetwork : MonoBehaviour{
    GameObject localPlayer;
    string localPlayerName;
    public Text playerName;


   // public RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };

    // Use this for initialization

    void Awake()
    {

      
        localPlayer = GameObject.Find("PlayerInfo");
        print("Connecting to server");
        PhotonNetwork.ConnectUsingSettings("0.1");
        PhotonNetwork.GetRoomList();
        //Debug.Log(PhotonNetwork.countOfRooms);
    }
    void Start () {

       


    }

    public virtual void OnConnectedToMaster()
    {
        print("Connected To Master");
       
    }


  


    public virtual void OnJoinedLobby ()
    {
       print("joined lobby");
       PhotonNetwork.playerName = localPlayer.GetComponent<LocalPlayerInfo>().localPlayerName;
       //playerName.text = localPlayer.GetComponent<LocalPlayerInfo>().localPlayerName;
        PhotonNetwork.GetRoomList();
    }

    public void OnClickCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        PhotonNetwork.CreateRoom("Room 1", roomOptions, TypedLobby.Default);
        //Debug.Log(PhotonNetwork.countOfRooms);

    }

    
	// Update is called once per frame
	void Update () {

        
		
	}
}
