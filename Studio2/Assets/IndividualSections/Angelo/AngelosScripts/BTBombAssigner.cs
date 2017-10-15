using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBombAssigner : MonoBehaviour
{
    public List<BTPlayer> playerList = new List<BTPlayer>();
    public BTBomb myBomb;

    private void Awake()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i <= 4; i++)
        {
            playerList.Add(tempArray[i].GetComponent<BTPlayer>());
        }
    }

    private void RemovePlayer()
    {

    }

    private void RandomizeAndAssign()
    {
        int randomGen = Random.Range(0, playerList.Count);
        myBomb.SetBombOwner(playerList[randomGen].gameObject);
        playerList[randomGen].currentPlayerState = BTPlayerState.hasBomb;
    }
}
