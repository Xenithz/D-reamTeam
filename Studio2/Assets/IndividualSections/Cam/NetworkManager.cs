using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum GameStates
{
    Starting,
    InProgress,
    GameOver
}
public class NetworkManager : Photon.MonoBehaviour {
   // public static NetworkManager Instance; 
    [SerializeField]private Text connectionText;
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject[] spawnpoints;
    public List<GameObject> allPlayers = new List<GameObject> ();
    private int playerInRoom = 0; 
 


    //[SerializeField]private GameObject lobbyCamera;

    // Use this for initialization
    void Start () {

        PhotonNetwork.ConnectUsingSettings("0.1");
		
	}
	

    public virtual void OnJoinedLobby()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinOrCreateRoom("New", null, null);
    }

    public virtual void OnJoinedRoom()
    {
      GameObject localPlayer =  PhotonNetwork.Instantiate(player.name,spawnpoints[PhotonNetwork.player.ID-1].transform.position, Quaternion.identity,0);
      allPlayers.Add(localPlayer);
    

        
    }
	// Update is called once per frame
	void Update () {

        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
		
	}
}
