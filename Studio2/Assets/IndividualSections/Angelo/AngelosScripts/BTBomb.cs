using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBomb : MonoBehaviour
{
    public float timeTillExplosion = 30;
    public float currentTimeTillExplosion; 

    public GameObject bombOwner;
    public BTPlayer bombOwnerPlayer;

    public int offSet = 5;

    private void Awake()
    {
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
        this.gameObject.transform.SetParent(bombOwner.transform);
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + offSet, this.gameObject.transform.position.z);
    }

    public void DestroyOwner(GameObject owner)
    {
        GameObject.Destroy(owner);
        this.bombOwner = null;
        currentTimeTillExplosion = timeTillExplosion;
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
