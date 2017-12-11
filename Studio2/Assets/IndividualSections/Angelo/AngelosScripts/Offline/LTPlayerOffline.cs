using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTPlayerOffline : MonoBehaviour
{
    public int position;
    public List<Vector3> positionVectors;
    public bool goNow;
    public float currentCDTime;
    public float setCDTime;


    private void Start()
    {
        position = 0;
        goNow = false;
        currentCDTime = setCDTime;
        positionVectors.Add(new Vector3(this.transform.position.x, this.transform.position.y, -11.5f));
        positionVectors.Add(new Vector3(this.transform.position.x, this.transform.position.y, -11.7f));
        positionVectors.Add(new Vector3(this.transform.position.x, this.transform.position.y, -11.9f));
    }
    
    private void Update()
    {
        if (goNow == true)
        {
            TimeTickDown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "laser")
        {
            if (goNow == false)
            {

                PushBack();
            }
        }
    }

    public void PushBack()
    {
        if (position == 0 || position == 1)
        {
            position++;
            gameObject.transform.position = positionVectors[position];
            goNow = true;
        }

        else if (position == 2)
        {
            gameObject.SetActive(false);
            goNow = true;
        }
    }

    public void TimeTickDown()
    {
        currentCDTime -= Time.deltaTime;
        if (currentCDTime <= 0)
        {
            currentCDTime = setCDTime;
            goNow = false;
        }
    }
}
