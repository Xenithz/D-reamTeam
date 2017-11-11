using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateRoom : MonoBehaviour {


    [SerializeField]
    private Text roomName;
    private Text _roomName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ClickCreateRoom()
    {
        if (PhotonNetwork.CreateRoom(_roomName.text))
        {
            print("create room sent");
        }

        else
        {
            print("create room did not send");
        }
    }

    void OnPhotonCreateRoomFaileed(object[] code)
    {
        print("Error Connecting to Room: " + code[1]);
    }
    
    void OnCreateRoom ()
    {

    }

}
