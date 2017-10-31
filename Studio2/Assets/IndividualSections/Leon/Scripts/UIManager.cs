using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Login Scene");
    }
    public void OnClickBombtag()
    {
        SceneManager.LoadScene("Bomb Tag Network");
    }

    public void OnClickSumoBall()
    {
        SceneManager.LoadScene("Sumo Ball Scene");

        
    }

    public void OnClickLaserJump()
    {
        SceneManager.LoadScene("Laser Jump Scene");
    }

    public void OnClickBackToMain()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
