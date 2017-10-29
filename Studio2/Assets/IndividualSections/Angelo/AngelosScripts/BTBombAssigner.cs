using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBombAssigner : NetworkManager
{
    public List<GameObject> playerList = new List<GameObject>();
    public BTBomb myBomb;

    private void Awake()
    {

        
    }

    public void AddPlayers()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("PlayerP");

        for (int i = 0; i < 4; i++)
        {
            playerList.Add(tempArray[i]);
            Debug.Log(playerList.Count);
        }
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
