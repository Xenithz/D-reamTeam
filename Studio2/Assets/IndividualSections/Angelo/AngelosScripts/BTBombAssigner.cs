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
    }

    [PunRPC]
    public void AddPlayers()
    {
        // GameObject[] tempArray = GameObject.FindGameObjectsWithTag("PlayerP");
        playerList = new List<GameObject>(NetworkManager.Instance.allPlayers);
        NetworkManager.Instance.currentGameState = GameStates.InProgress;

       /* for (int i = 0; i < NetworkManager.Instance.allPlayers.Count; i++)
        {
            playerList.Add(NetworkManager.Instance.allPlayers[i]);
            Debug.Log(playerList.Count);
        }*/
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

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
    public void RandomizeAndAssign()
    {
        int randomGen = Random.Range(0, playerList.Count);
        myBomb.SetBombOwner(playerList[randomGen]);
        //playerList[randomGen].GetComponent<BTPlayer>().currentPlayerState = BTPlayerState.hasBomb;
    }
}
