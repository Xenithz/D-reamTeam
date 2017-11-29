using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> backGroundMusic = new List<AudioClip>();
    public List<AudioClip> soundEffects = new List<AudioClip>();

    public AudioSource backGroundSource;

    public static AudioManager instance = new AudioManager();

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(backGroundSource.isPlaying == false)
        {
            ShuffleStart();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            backGroundSource.Stop();
        }
    }

    private void Start()
    {
        ShuffleStart();
    }

    public void ShuffleStart()
    {
        if(backGroundSource.isPlaying == true)
        {
            backGroundSource.Stop();
        }

        int myRandom = Random.Range(1, backGroundMusic.Count);
        backGroundSource.PlayOneShot(backGroundMusic[myRandom]);
    }

    public void PlaySFX(AudioSource sourceToPlayIn, int index)
    {
        sourceToPlayIn.PlayOneShot(soundEffects[index]);
    }

    public void PlaySFX(AudioSource sourceToPlayIn, int index, float timeToStart, float timeToEnd)
    {
        sourceToPlayIn.clip = soundEffects[index];
        sourceToPlayIn.SetScheduledStartTime((double)timeToStart);
        sourceToPlayIn.SetScheduledEndTime((double)timeToEnd);
        sourceToPlayIn.Play();
    }
}
