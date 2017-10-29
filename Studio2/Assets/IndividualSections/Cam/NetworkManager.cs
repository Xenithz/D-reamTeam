using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum GameStates
{
    SetUp,
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
    public GameStates currentGameState = GameStates.SetUp;
    //public GameObject myInstance; 


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

    public virtual void OnDisconnectedFromPhoton()
    {
        for(int i = 0; i < allPlayers.Count; i++)
        {
            if(allPlayers[i] == null)
            {
                allPlayers.Remove(allPlayers[i]);
            } 
          
        }
    }

    public virtual void OnJoinedRoom()
    {
      GameObject localPlayer =  PhotonNetwork.Instantiate(player.name,spawnpoints[PhotonNetwork.player.ID-1].transform.position, Quaternion.identity,0);
       // myInstance = localPlayer; 
        this.photonView.RPC("AddToList", PhotonTargets.AllBufferedViaServer, localPlayer.name);
        this.photonView.RPC("CheckPlayerList", PhotonTargets.AllBuffered);
    

        
    }


    [PunRPC]
    public void CheckPlayerList()
    {
        if (PhotonNetwork.playerList.Length > 1)
        {
            currentGameState = GameStates.Starting;
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
