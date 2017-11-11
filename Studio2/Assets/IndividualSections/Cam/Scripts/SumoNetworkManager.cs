using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SumoNetworkManager : Photon.MonoBehaviour, IPunObservable
{
    static public SumoNetworkManager Instance;
    [SerializeField]
    private Text connectionText;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    private GameObject[] spawnpoints;
    public List<GameObject> playersAlive;
    SBPlayerHandler SBPH;
    public List<GameObject> allPlayers = new List<GameObject>();
    private int playerInRoom = 0;
    public GameObject resultPanel;
    public Text resultText;
    public GameStates currentGameState = GameStates.SetUp;
    //public GameObject myInstance; 


    //[SerializeField]private GameObject lobbyCamera;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        resultPanel.SetActive(false);
        PhotonNetwork.ConnectUsingSettings("0.1");
        SBPH = GetComponent<SBPlayerHandler>();
        resultText = resultPanel.GetComponentInChildren<Text>();


    }


    public virtual void OnJoinedLobby()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinOrCreateRoom("New2", null, null);
    }

    public virtual void OnDisconnectedFromPhoton()
    {
        for (int i = 0; i < allPlayers.Count; i++)
        {
            if (allPlayers[i] == null)
            {
                allPlayers.Remove(allPlayers[i]);
            }

        }
    }

    public virtual void OnJoinedRoom()
    {

        GameObject localPlayer = PhotonNetwork.Instantiate(player.name, spawnpoints[PhotonNetwork.player.ID - 1].transform.position, Quaternion.identity, 0);
        // myInstance = localPlayer; 

        this.photonView.RPC("AddToList", PhotonTargets.AllBufferedViaServer, localPlayer.name);
        this.photonView.RPC("CheckPlayerList", PhotonTargets.AllBuffered);





    }


    [PunRPC]
    public void CheckPlayerList()
    {
        if (PhotonNetwork.playerList.Length > 2)
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



    [PunRPC] //Displays winner and changes game state to Game Over
    public void DisplayResults()
    {
        currentGameState = GameStates.GameOver;
        resultPanel.SetActive(true);
        resultText.text = SBPH.playerList[0].name + " wins!";

    }

    void Update()
    {
        //creates reference to playerlist 
       
        connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
        //checks if there is one player left and displays the winner
     /*  if (SBPH.playerList.Count <= 1 && currentGameState == GameStates.InProgress)
        {
            //display results here.
            this.photonView.RPC("DisplayResults", PhotonTargets.AllViaServer);

            // DisplayResults();

        }*/
        //Debug.Log(currentGameState);

    }
}