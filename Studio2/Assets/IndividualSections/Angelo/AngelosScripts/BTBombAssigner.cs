using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBombAssigner : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();
    public BTBomb myBomb;

    private void Awake()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("PlayerP");

        for (int i = 0; i < 4; i++)
        {
            playerList.Add(tempArray[i]);
            Debug.Log(playerList.Count);
        }
    }

    private void RemovePlayer()
    {

    }

    public void RandomizeAndAssign()
    {
        int randomGen = Random.Range(0, playerList.Count);
        myBomb.SetBombOwner(playerList[randomGen]);
        //playerList[randomGen].GetComponent<BTPlayer>().currentPlayerState = BTPlayerState.hasBomb;
    }
}
