using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class LTGenerator : Photon.MonoBehaviour, IPunObservable
{
    public Vector3[] spawnSpots;
    public bool callMe;
    public bool callMe2;
    public float currentTime;
    public float timeToSet;
    public int stage;

    public void Awake()
    {
        callMe = true;
        callMe2 = true;
        currentTime = timeToSet;
        stage = -1;
    }

    public void Update()
    {
        if(LTNetworkManager.Instance.currentGameState == GameStates.InProgress)
        {
            Timer();

            if (callMe == true && stage == 0)
            {
                StartCoroutine(ThrowLaser());
            }
            
            else if(callMe == true && stage == 1)
            {
                StopCoroutine(ThrowLaser());
                StartCoroutine(ThrowLaser2());
            }

            //else if (callMe == true && stage == 2)
            //{
            //    StopCoroutine(ThrowLaser2());
            //    StartCoroutine(ThrowLaser3());
            //}

            //else if (callMe == true && stage == 3)
            //{
            //    StopCoroutine(ThrowLaser3());
            //    StartCoroutine(ThrowLaser4());
            //}
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
       if(callMe2 == true)
        {
            Debug.Log("running");
            if (input == "1")
            {
                Debug.Log("red");
                GameObject redLaser = ObjectPooler.instance.GiveMeALaser("red");
                if (redLaser != null)
                {
                    redLaser.transform.position = spawnSpots[0];
                    redLaser.SetActive(true);
                    callMe2 = false;
                }
            }

            else if (input == "2")
            {
                Debug.Log("bue");
                GameObject blueLaser = ObjectPooler.instance.GiveMeALaser("blue");
                if (blueLaser != null)
                {
                    blueLaser.transform.position = spawnSpots[1];
                    blueLaser.SetActive(true);
                    callMe2 = false;
                }
            }
        }
    }

    //Speed 2
    public IEnumerator ThrowLaser()
    {
        callMe = false;
        for(int i = 0; i < ObjectPooler.instance.amountToCreate; i++)
        {
            ObjectPooler.instance.myBluePool[i].GetComponent<LaserMove>().speed = 2;
            ObjectPooler.instance.myRedPool[i].GetComponent<LaserMove>().speed = 2;
        }
        while (true)
        {
            if (PhotonNetwork.player == PhotonNetwork.masterClient)
            {
                photonView.RPC("RandomizeValue", PhotonTargets.MasterClient);
            }
            yield return new WaitForSeconds(3);
            callMe2 = true;
        }
    }

    //Speed 3
    public IEnumerator ThrowLaser2()
    {
        callMe = false;
        for (int i = 0; i < ObjectPooler.instance.amountToCreate; i++)
        {
            ObjectPooler.instance.myBluePool[i].GetComponent<LaserMove>().speed = 3;
            ObjectPooler.instance.myRedPool[i].GetComponent<LaserMove>().speed = 3;
        }
        while (true)
        {
            if (PhotonNetwork.player == PhotonNetwork.masterClient)
            {
                photonView.RPC("RandomizeValue", PhotonTargets.MasterClient);
            }
            yield return new WaitForSeconds(3);
            callMe2 = true;
        }
    }

    ////Speed 4
    //public IEnumerator ThrowLaser3()
    //{
    //    callMe = false;
    //    for (int i = 0; i < ObjectPooler.instance.amountToCreate; i++)
    //    {
    //        ObjectPooler.instance.myBluePool[i].GetComponent<LaserMove>().speed = 4;
    //        ObjectPooler.instance.myRedPool[i].GetComponent<LaserMove>().speed = 4;
    //    }
    //    while (true)
    //    {
    //        if (PhotonNetwork.player == PhotonNetwork.masterClient)
    //        {
    //            photonView.RPC("RandomizeValue", PhotonTargets.MasterClient);
    //        }
    //        yield return new WaitForSeconds(3);
    //        callMe2 = true;
    //    }
    //}

    ////Speed 5
    //public IEnumerator ThrowLaser4()
    //{
    //    callMe = false;
    //    for (int i = 0; i < ObjectPooler.instance.amountToCreate; i++)
    //    {
    //        ObjectPooler.instance.myBluePool[i].GetComponent<LaserMove>().speed = 5;
    //        ObjectPooler.instance.myRedPool[i].GetComponent<LaserMove>().speed = 5;
    //    }
    //    while (true)
    //    {
    //        if (PhotonNetwork.player == PhotonNetwork.masterClient)
    //        {
    //            photonView.RPC("RandomizeValue", PhotonTargets.MasterClient);
    //        }
    //        yield return new WaitForSeconds(3);
    //        callMe2 = true;
    //    }
    //}

    public void Timer()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = timeToSet;
            stage++;
            callMe = true;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
