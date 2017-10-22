using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCreate : MonoBehaviour {
    public GameObject GO;
    public Vector3[] obstaclePos;
    int obstaclePosNum;
    public float time;
    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        obstaclePosNum = Random.Range(0, obstaclePos.Length);

        if (time <= 0)
        {
            Instantiate(GO, obstaclePos[obstaclePosNum], Quaternion.identity);

            time = 3;

        }
    }
}
