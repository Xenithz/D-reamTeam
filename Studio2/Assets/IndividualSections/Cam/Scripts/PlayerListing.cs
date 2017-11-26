using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : Photon.MonoBehaviour,IPunObservable {

    public GameObject[] playerPanels;
    public GameObject playerPlate;
    public GameObject[] plateHolders;
    public Text playerName;
    public int numOfPlayers;
    public PhotonPlayer[] photonPlayers;


    public void OnJoinedRoom()
    {


        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            GameObject namePlate = PhotonNetwork.Instantiate("NamePlate", plateHolders[i].transform.position, Quaternion.identity, 0) as GameObject;
            namePlate.transform.parent = plateHolders[i].transform;
            namePlate.GetComponentInChildren<Text>().text = PhotonNetwork.playerList[i].NickName;
        }
    }


    public void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        photonPlayers = PhotonNetwork.playerList;
        for(int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            if (plateHolders[i].transform.childCount==0)
            {

                GameObject namePlate = PhotonNetwork.Instantiate("NamePlate", plateHolders[i].transform.position, Quaternion.identity, 0) as GameObject;
                namePlate.transform.parent = plateHolders[i].transform;
                namePlate.GetComponentInChildren<Text>().text = newPlayer.NickName;
            }
        }

        
    }

   

  

    void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        //GameObject.Find(photonPlayer.NickName).GetComponent<Text>().text = "";
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

}
