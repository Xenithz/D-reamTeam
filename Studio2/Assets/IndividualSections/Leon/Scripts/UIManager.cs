using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {


    public Transform logIn;
    public Transform register;
    

    
	
    
    public void OnClickSignUp()  //to play and pause the game and the audio clip.
    {
        
        
            logIn.gameObject.SetActive(false);
            register.gameObject.SetActive(true);
        
        
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
