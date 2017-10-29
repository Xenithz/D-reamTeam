using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBombAssigner : Photon.MonoBehaviour, IPunObservable
{
    public List<GameObject> playerList = new List<GameObject>();
    public BTBomb myBomb;

    private void Awake()
    {

        
    }

    void FixedUpdate ()
    {
        if (NetworkManager.Instance.currentGameState == GameStates.Starting)
        {
            NetworkManager.Instance.photonView.RPC("AddPlayers", PhotonTargets.All);
        }

        if(NetworkManager.Instance.currentGameState == GameStates.Assigning)
        {
            NetworkManager.Instance.photonView.RPC("RandomizeAndAssign", PhotonTargets.All);
        }
    }

    [PunRPC]
    public void AddPlayers()
    {
        // GameObject[] tempArray = GameObject.FindGameObjectsWithTag("PlayerP");
        playerList = new List<GameObject>(NetworkManager.Instance.allPlayers);
        NetworkManager.Instance.currentGameState = GameStates.Assigning;

       /* for (int i = 0; i < NetworkManager.Instance.allPlayers.Count; i++)
        {
            playerList.Add(NetworkManager.Instance.allPlayers[i]);
            Debug.Log(playerList.Count);
        }*/
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    [PunRPC]
    public void SetBomb(string randomInt)
    {
        myBomb.SetBombOwner(playerList[int.Parse(randomInt)]);
        NetworkManager.Instance.currentGameState = GameStates.InProgress;

    }

    //Function removes a player from the list
    public void RemovePlayer(GameObject gameObjecToCheckFor)
    {
        if (playerList.Contains(gameObjecToCheckFor))
        {
            for(int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i] == gameObjecToCheckFor)
                {
                    playerList.Remove(playerList[i]);
                }
            }
        }
    }

    //Function randomly chooses a player from the list and assigns the bomb to them
    [PunRPC]
    public void RandomizeAndAssign()
    {
        int randomGen = Random.Range(0, playerList.Count);
        if (PhotonNetwork.isMasterClient)
        {
            NetworkManager.Instance.photonView.RPC("SetBomb", PhotonTargets.All, randomGen.ToString());
            Debug.Log(randomGen);
            
        }
        //playerList[randomGen].GetComponent<BTPlayer>().currentPlayerState = BTPlayerState.hasBomb;
    }
}
