using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSpawner : MonoBehaviour
{
    public List<BTPlayer> playerList = new List<BTPlayer>();

    private void Awake()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("Player");
        
        for(int i = 0; i <=4 ; i++)
        {
            playerList.Add(tempArray[i].GetComponent<BTPlayer>());
        }
    }

    private void RemovePlayer()
    {

    }

    private void Randomize()
    {

    }
}
