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
public class NetworkManager : Photon.MonoBehaviour, IPunObservable{ 
    static public NetworkManager Instance; 
    [SerializeField]private Text connectionText;
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject[] spawnpoints;
    public List<GameObject> allPlayers = new List<GameObject> ();
    private int playerInRoom = 0;
    static public GameStates currentGameState = GameStates.Starting;


    //[SerializeField]private GameObject lobbyCamera;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
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
        this.photonView.RPC("AddToList", PhotonTargets.All, localPlayer.name);
        this.photonView.RPC("CheckPlayerList", PhotonTargets.All);
    

        
    }
    [PunRPC]
    public void CheckPlayerList()
    {
        if (PhotonNetwork.playerList.Length > 1)
        {
            currentGameState = GameStates.InProgress;
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }


    [PunRPC]
    public void AddToList(string localPlayerName)
    {
        GameObject localPlayer = GameObject.Find(localPlayerName);
        allPlayers.Add(localPlayer);
        Debug.Log("joined");

    }
    // Update is called once per frame
    void Update () {

        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
        Debug.Log(currentGameState);
		
	}
}
