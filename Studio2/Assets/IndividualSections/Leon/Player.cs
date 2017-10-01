using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isBomb;
    public PlayerNumber playerNumber;
    public Transform bomb;
    
    
    // Use this for initialization
    void Start () {
        playerNumber = GameObject.FindGameObjectWithTag("PlayerList").GetComponent<PlayerNumber>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isBomb)
        {
            bomb.gameObject.SetActive(true);
           
        }
        else
        
        {
            bomb.gameObject.SetActive(false);
        }
        
      
    }

    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Bomb")
        {
            isBomb = true;      
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            isBomb = false;
            
        }




    }
}
