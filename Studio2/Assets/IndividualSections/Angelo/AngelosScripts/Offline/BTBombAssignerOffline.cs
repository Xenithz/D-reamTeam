using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBombAssignerOffline : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();
    public BTBombOffline myBomb;

    private void Awake()
    {
    }

    private void Start()
    {
        AddPlayers();
        RandomizeAndAssign();
    }

    public void AddPlayers()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("PlayerP");
        playerList = new List<GameObject>();

        for (int i = 0; i < tempArray.Length; i++)
        {
            playerList.Add(tempArray[i]);
        }
    }

    public void SetBomb(string randomInt)
    {
        myBomb.SetBombOwner(playerList[int.Parse(randomInt)].name);

    }

    //Function removes a player from the list
    public void RemovePlayer(string gameObjectToCheckForName)
    {
        GameObject gameObjecToCheckFor = GameObject.Find(gameObjectToCheckForName);
        if (playerList.Contains(gameObjecToCheckFor))
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i] == gameObjecToCheckFor)
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
        SetBomb(randomGen.ToString());
    }
}
