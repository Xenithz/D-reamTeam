using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class LTGenerator : Photon.MonoBehaviour, IPunObservable
{
    public Vector3[] spawnSpots;
    public bool callMe;

    public void Awake()
    {
        callMe = true;
    }

    public void Update()
    {
        if(LTNetworkManager.Instance.currentGameState == GameStates.InProgress)
        {
            if(callMe == true)
            {
                StartCoroutine(ThrowLaser());
            }
        }
    }

    [PunRPC]
    public void RandomizeValue()
    {
        int randomGen = Random.Range(1, 3);
        Debug.Log(randomGen);
        photonView.RPC("SpawnLaser", PhotonTargets.AllViaServer, randomGen.ToString());
    }

    [PunRPC]
    public void SpawnLaser(string input)
    {
        Debug.Log("running");
        if(input == "1")
        {
            Debug.Log("red");
            GameObject redLaser = ObjectPooler.instance.GiveMeALaser("red");
            if(redLaser != null)
            {
                redLaser.transform.position = spawnSpots[0];
                redLaser.SetActive(true);
            }
        }

        else if(input == "2")
        {
            Debug.Log("bue");
            GameObject blueLaser = ObjectPooler.instance.GiveMeALaser("blue");
            if(blueLaser != null)
            {
                blueLaser.transform.position = spawnSpots[1];
                blueLaser.SetActive(true);
            }
        }
    }

    public IEnumerator ThrowLaser()
    {
        callMe = false;
        while (true)
        {
            photonView.RPC("RandomizeValue", PhotonTargets.AllViaServer);
            yield return new WaitForSeconds(3);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
