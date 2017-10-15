using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBomb : MonoBehaviour
{
    public float timeTillExplosion = 5;
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
        if(bombOwner != null)
        {
            TimeTickDown();
        }
    }

    public void SetBombOwner(GameObject newBombOwner)
    {
        if(bombOwnerPlayer != null)
        {
            bombOwnerPlayer.myBomb = null;
        }

        bombOwner = newBombOwner;
        bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
        bombOwnerPlayer.currentPlayerState = BTPlayerState.hasBomb;
        bombOwnerPlayer.myBomb = this;
        this.gameObject.transform.SetParent(bombOwner.transform);
        this.gameObject.transform.position = new Vector3(bombOwner.transform.position.x, bombOwner.transform.position.y + offSet, bombOwner.transform.position.z);
    }

    public void DestroyOwner(GameObject owner)
    {
        gameObject.transform.parent = null;
        GameObject.Destroy(owner);
        this.bombOwner = null;
        currentTimeTillExplosion = timeTillExplosion;
    }

    public void TimeTickDown()
    {
        currentTimeTillExplosion -= Time.deltaTime;
        if(currentTimeTillExplosion <= 0)
        {
            Debug.Log("destroy");
            DestroyOwner(bombOwner);
        }
    }
}
