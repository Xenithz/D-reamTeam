    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class ObjectPooler : Photon.MonoBehaviour
{
    public static ObjectPooler instance;
    public GameObject redLaser;
    public GameObject blueLaser;
    public List<GameObject> myRedPool;
    public List<GameObject> myBluePool;
    public int amountToCreate;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        myRedPool = new List<GameObject>();
        myBluePool = new List<GameObject>();
        for(int i = 0; i < amountToCreate; i++)
        {
            GameObject temp = (GameObject)Instantiate(redLaser);
            GameObject temp2 = (GameObject)Instantiate(blueLaser);
            temp.SetActive(false);
            temp2.SetActive(false);
            myRedPool.Add(temp);
            myBluePool.Add(temp2);
        }
    }

    public GameObject GiveMeALaser(string color)
    {
        if (color == "red")
        {
            for(int i = 0; i < myRedPool.Count; i++)
            {
                if (!myRedPool[i].activeInHierarchy)
                {
                    return myRedPool[i];
                }
            }
            return null;
        }

        if (color == "blue")
        {
            for(int i = 0; i < myBluePool.Count; i++)
            {
                if (!myBluePool[i].activeInHierarchy)
                {
                    return myBluePool[i];
                }
            }
            return null;
        }

        return null;
    }
}
