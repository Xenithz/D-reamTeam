using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBomb : MonoBehaviour
{
    public float timeTillExplosion = 30;
    public float currentTimeTillExplosion; 

    public GameObject bombOwner;
    public BTPlayer bombOwnerPlayer;

    private void Awake()
    {
        bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
        currentTimeTillExplosion = timeTillExplosion;
    }

    private void Update()
    {
        TimeTickDown();
    }

    public void SetBombOwner(GameObject newBombOwner)
    {
        bombOwnerPlayer.myBomb = null;
        bombOwner = newBombOwner;
        bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
        bombOwnerPlayer.currentPlayerState = BTPlayerState.hasBomb;
        bombOwnerPlayer.myBomb = this;
    }

    public void DestroyOwner(GameObject owner)
    {
        GameObject.Destroy(owner);
        this.bombOwner = null;
    }

    public void TimeTickDown()
    {
        currentTimeTillExplosion -= Time.deltaTime;
        
        if(currentTimeTillExplosion <= 0)
        {
            DestroyOwner(bombOwner);
        }
    }
}
