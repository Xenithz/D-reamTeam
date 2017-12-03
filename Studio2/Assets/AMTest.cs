using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMTest : MonoBehaviour
{
    public AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    AudioManager.instance.PlaySFX(myAudioSource, 0);
        //}
    }
}
