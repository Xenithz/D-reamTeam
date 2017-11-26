using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTLaserRepool : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RepoolBox")
        {
            gameObject.SetActive(false);
        }
    }
}
