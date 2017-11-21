using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {
    Vector3 pos;
    public float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (pos.z <= -27.7)
        {
            pos.z = 7.7f;
            transform.position = pos;
        }
    }
}


    
   