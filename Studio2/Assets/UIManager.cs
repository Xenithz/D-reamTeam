﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {
    public Transform helpCanvas;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game Pick Scene");
    }
    public void OnClickBombtag()
    {
        SceneManager.LoadScene("Bomb Tag");
    }

    public void OnClickBackToMain()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void OnClickHelp()
    {
        if (!helpCanvas.gameObject.activeInHierarchy)
        {
            helpCanvas.gameObject.SetActive(true);
           


        }
        else
        {
            helpCanvas.gameObject.SetActive(false);
            


        }
        
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
