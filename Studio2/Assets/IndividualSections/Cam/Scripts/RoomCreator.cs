using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoomCreator : MonoBehaviour {

    public GameObject[] roomPanel;
    //public Text roomName;
    private Text roomName;
    public Text InputRoomName;
    int numOfRooms;



    void Start()
    {
        
    }

    

    public virtual void OnReceivedRoomListUpdate ()
    {
        Debug.Log("checking existing rooms");
        
        if (PhotonNetwork.GetRoomList().Length > 0)
        {
            RoomInfo[] rooms = PhotonNetwork.GetRoomList();
            foreach (RoomInfo room in rooms)
            {
                roomPanel[PhotonNetwork.GetRoomList().Length-1].SetActive(true);
                roomPanel[PhotonNetwork.GetRoomList().Length-1].GetComponent<Text>().text = room.Name; 
            }
        }
    }

    



    void OnPhotonCreateRoomFailed(object[] code)
    {
        print("Error Connecting to Room: " + code[1]);
    }
    
 

}
