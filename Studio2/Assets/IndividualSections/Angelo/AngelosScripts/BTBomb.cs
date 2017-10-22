using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBomb : MonoBehaviour
{
    #region PublicVariables

    public float timeTillExplosion = 5;
    public float timeTillSwitch = 1;
    public float currentTimeTillExplosion;
    public float currentTimeTillCanSwitch;

    public GameObject bombOwner;
    public BTPlayer bombOwnerPlayer;
    public BTBombAssigner myAssigner;

    public int offSet = 5;

    public bool bombIsAbleToSwitch;

    #endregion

    #region MyFunctions

    //Function checks if bomb can switch first, then transfers complete ownership of the bomb to the next player
    public void SetBombOwner(GameObject newBombOwner)
    {
        if (bombIsAbleToSwitch == true)
        {
            bombIsAbleToSwitch = false;

            if (bombOwnerPlayer != null)
            {
                bombOwnerPlayer.myBomb = null;
            }

            bombOwner = newBombOwner;
            bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
            bombOwnerPlayer.currentPlayerState = BTPlayerState.hasBomb;
            bombOwnerPlayer.myBomb = this;
            this.gameObject.transform.SetParent(bombOwner.transform);
            this.gameObject.transform.position = new Vector3(bombOwner.transform.position.x, bombOwner.transform.position.y + offSet, bombOwner.transform.position.z);
            currentTimeTillCanSwitch = 1;
            Debug.Log("ACCESSED");
        }
    }

    //Function destroys the current owner
    public void DestroyOwner(GameObject owner)
    {
        myAssigner.RemovePlayer(owner);
        gameObject.transform.parent = null;
        GameObject.Destroy(owner);
        this.bombOwner = null;
        currentTimeTillExplosion = timeTillExplosion;
        myAssigner.RandomizeAndAssign();
    }

    //Function ticks down time for explosion
    public void TimeTickDown()
    {
        currentTimeTillExplosion -= Time.deltaTime;
        if (currentTimeTillExplosion <= 0)
        {
            Debug.Log("destroy");
            DestroyOwner(bombOwner);
        }
    }

    //Function ticks down time for switching cooldown
    public void SwitchCooldown()
    {
        currentTimeTillCanSwitch -= Time.deltaTime;
        if (currentTimeTillCanSwitch <= 0)
        {
            bombIsAbleToSwitch = true;
        }
    }

    #endregion

    #region UnityFunctions

    private void Awake()
    {
        currentTimeTillExplosion = timeTillExplosion;
        currentTimeTillCanSwitch = timeTillSwitch;
        bombIsAbleToSwitch = true;
    }

    private void Update()
    {
        if (bombOwner != null)
        {
            TimeTickDown();
        }

        if (bombIsAbleToSwitch == false)
        {
            SwitchCooldown();
        }
    }

    #endregion
}
