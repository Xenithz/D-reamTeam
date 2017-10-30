﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBomb : Photon.MonoBehaviour, IPunObservable
{
    #region PublicVariables

    public float timeTillExplosion = 5;
    public float timeTillSwitch = 1;
    public float currentTimeTillExplosion;
    public float currentTimeTillCanSwitch;

    public GameObject bombOwner;
    public GameObject bomb;
    public BTPlayer bombOwnerPlayer;
    public BTBombAssigner myAssigner;

    public int offSet = 5;

    public bool bombIsAbleToSwitch;

    #endregion

    #region MyFunctions

    //Function checks if bomb can switch first, then transfers complete ownership of the bomb to the next player
    [PunRPC]
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
            bombOwnerPlayer = bombOwner.GetComponent<BTPlayer>();
            bombOwnerPlayer.currentPlayerState = BTPlayerState.hasBomb;
            bombOwnerPlayer.myBomb = this;
            bomb.transform.SetParent(bombOwner.transform);
            bomb.transform.position = new Vector3(bombOwner.transform.position.x, bombOwner.transform.position.y + offSet, bombOwner.transform.position.z);
            currentTimeTillCanSwitch = 1;
            Debug.Log("ACCESSED");
        }
    }

    //Function destroys the current owner
    [PunRPC]
    public void DestroyOwner(string ownerName)
    {
        GameObject owner = GameObject.Find(ownerName);
        NetworkManager.Instance.photonView.RPC("RemovePlayer", PhotonTargets.All, ownerName);
        gameObject.transform.parent = null;
        GameObject.Destroy(owner);
        this.bombOwner = null;
        currentTimeTillExplosion = timeTillExplosion;
        NetworkManager.Instance.photonView.RPC("RandomizeAndAssign", PhotonTargets.MasterClient);
    }


    //Function ticks down time for explosion
    public void TimeTickDown()
    {
        currentTimeTillExplosion -= Time.deltaTime;
        if (currentTimeTillExplosion <= 0)
        {
            Debug.Log("destroy");
            NetworkManager.Instance.photonView.RPC("DestroyOwner", PhotonTargets.All, bombOwner.name);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

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
