using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> backGroundMusic;
    public List<AudioClip> bTSoundEffects;
    public List<AudioClip> sBSoundEffects;
    public List<AudioClip> lTSoundEffects;

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
        backGroundSource = GetComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        backGroundSource.clip = backGroundMusic[0];
        backGroundSource.loop = true;
        backGroundSource.Play();
    }

    private void Update()
    {
        //if(backGroundSource.isPlaying == false)
        //{
        //    ShuffleStart();
        //}
    }

    private void Start()
    {
        //ShuffleStart();
    }

    public void ShuffleStart()
    {
        if(backGroundSource.isPlaying == true)
        {
            backGroundSource.Stop();
            backGroundSource.loop = false;
        }

        int myRandom = Random.Range(1, backGroundMusic.Count);
        backGroundSource.PlayOneShot(backGroundMusic[myRandom]);
    }

    public void PlaySFX(AudioSource sourceToPlayIn, int index, List<AudioClip> soundList)
    {
        sourceToPlayIn.PlayOneShot(soundList[index]);
    }

    public void PlaySFX(AudioSource sourceToPlayIn, int index, float timeToStart, float timeToEnd, List<AudioClip> soundList)
    {
        sourceToPlayIn.clip = soundList[index];
        sourceToPlayIn.SetScheduledStartTime((double)timeToStart);
        sourceToPlayIn.SetScheduledEndTime((double)timeToEnd);
        sourceToPlayIn.Play();
    }

    public void PlayBackground(int index)
    {
        if (backGroundSource.isPlaying == true)
        {
            backGroundSource.Stop();
            backGroundSource.loop = true;
        }
        backGroundSource.clip = backGroundMusic[index];
        backGroundSource.Play();
    }

    
}
