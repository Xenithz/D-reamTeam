using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon;
using UnityEngine.SceneManagement;
using UnityEngine;





public class LoginSystem : PunBehaviour {
    public string inputUsername;
    public string inputPassword;
    public Text userField;
    public Text passwordField;
    public GameObject userHandler;
    public string loginUrl = "https://cosmicchaos.000webhostapp.com/network/Login.php"; 

	IEnumerator Login (string username, string password)
    {
        Debug.Log("enter");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(loginUrl, form);
        yield return www;
        Debug.Log(www.text);
        Debug.Log("returned");
        if (www.text == "login successful")
        {
            Debug.Log(www.text);
            LogInPlayer();
        }

        else if (www.text == "login failed")
        {
            Debug.Log(www.text);
        }
        
    }


    void Awake()
    {
        loginUrl = "https://cosmicchaos.000webhostapp.com/network/Login.php";
    }

public void OnLogin()
    {
        StartCoroutine(Login(inputUsername, inputPassword));
        

    }

    public void LogInPlayer()
    {
        SceneManager.LoadScene("Lobby");
        userHandler.GetComponent<LocalPlayerInfo>().localPlayerName = inputUsername;

    }

    public void GetUsername()
    {
        inputUsername = userField.text.ToString() ;

    }

    public void GetPassword()
    {
        inputPassword = passwordField.text.ToString();
    }

}
