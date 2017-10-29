using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        SetUp,
        Playing,
        End
    }

    public static GameManager gameManagerInstance;
    public GameObject playerPrefab;
    public GameObject localPlayer;

    private void Awake()
    {
        gameManagerInstance = this;
    }

    public virtual void SetUpGame()
    {

    }

    public virtual void UpdateGame()
    {

    }

    public virtual void EndGame()
    {

    }
}
