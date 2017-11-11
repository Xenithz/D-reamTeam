using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InfoUIManager : MonoBehaviour {

    GameObject PlayerInfo;
    public Text playerName; 
	// Use this for initialization
	void Start () {
        PlayerInfo = GameObject.Find("PlayerInfo");
        playerName.text = PlayerInfo.GetComponent<LocalPlayerInfo>().localPlayerName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
