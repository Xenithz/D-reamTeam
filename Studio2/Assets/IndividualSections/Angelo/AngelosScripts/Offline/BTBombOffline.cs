using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBombOffline : MonoBehaviour
{

    #region PublicVariables

    public float timeTillExplosion = 5;
    public float timeTillSwitch = 1;
    public float currentTimeTillExplosion;
    public float currentTimeTillCanSwitch;

    public GameObject bombOwner;
    public GameObject bomb;
    public BTPlayerOffline bombOwnerPlayer;
    public BTBombAssignerOffline myAssigner;

    public int offSet = 5;

    public bool bombIsAbleToSwitch;

    public bool goNow;

    #endregion

    #region MyFunctions

    //Function checks if bomb can switch first, then transfers complete ownership of the bomb to the next player
    public void SetBombOwner(string newBombOwnerName)
    {
        GameObject newBombOwner = GameObject.Find(newBombOwnerName);
        if (bombIsAbleToSwitch == true)
        {
            bombIsAbleToSwitch = false;

            if (bombOwnerPlayer != null)
            {
                bombOwnerPlayer.myBomb = null;
            }

            bombOwner = newBombOwner;
            bombOwnerPlayer = bombOwner.GetComponent<BTPlayerOffline>();
            bombOwnerPlayer.currentPlayerState = BTPlayerState.hasBomb;
            bombOwnerPlayer.myBomb = this;
            bomb.transform.SetParent(bombOwner.transform);
            bomb.transform.position = new Vector3(bombOwner.transform.position.x, bombOwner.transform.position.y + offSet, bombOwner.transform.position.z);
            AudioManager.instance.PlaySFX(bomb.GetComponent<AudioSource>(), 1, AudioManager.instance.bTSoundEffects);
            currentTimeTillCanSwitch = 1;
            goNow = true;
            Debug.Log("ACCESSED");
        }
    }

    //Function destroys the current owner
    public void DestroyOwner(string ownerName)
    {
        if (goNow == true)
        {
            if (myAssigner.playerList.Count == 1)
            {
                Destroy(bomb);
                return;
            }
            //AudioManager.instance.PlaySFX(bomb.GetComponent<AudioSource>(), 0, 0, 1.2f, AudioManager.instance.bTSoundEffects);
            GameObject owner = GameObject.Find(ownerName);
            myAssigner.RemovePlayer(ownerName);
            //gameObject.transform.parent = null;
            //GameObject.Destroy(owner);
            owner.SetActive(false);
            //this.bombOwner = null;
            currentTimeTillExplosion = timeTillExplosion;
            myAssigner.RandomizeAndAssign();
            goNow = false;
        }
        else
        {
            Debug.Log("Nice try");
        }
    }

    //Function ticks down time for explosion
    public void TimeTickDown()
    {
        currentTimeTillExplosion -= Time.deltaTime;
        if (currentTimeTillExplosion <= 0)
        {
            DestroyOwner(bombOwner.name);
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
        goNow = true;
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
