using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBomb : MonoBehaviour
{
    public int timeTillExplosion = 30;

    public GameObject bombOwner;
    public BTPlayer bombOwnerPlayer;

    private void Awake()
    {
        bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
    }

    public void SetBombOwner(GameObject newBombOwner)
    {
        bombOwnerPlayer.myBomb = null;
        bombOwner = newBombOwner;
        bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
        bombOwnerPlayer.currentPlayerState = BTPlayerState.hasBomb;
        bombOwnerPlayer.myBomb = this;
    }
}
