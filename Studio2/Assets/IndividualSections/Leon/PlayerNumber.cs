using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumber : MonoBehaviour {
    public int NumberofPlayers;
    public bool[] Players;
    // Use this for initialization
    void Start () {
        Players = new bool[NumberofPlayers];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
