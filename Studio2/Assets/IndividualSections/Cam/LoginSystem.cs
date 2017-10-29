using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon;
using UnityEngine;




public class LoginSystem : PunBehaviour {
    public string inputUsername;
    public string inputPassword;
    public Text userField;
    public Text passwordField; 
    public string loginUrl= "https://localhost/game/Login.php"; 

	IEnumerator Login (string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(loginUrl, form);
        yield return www;

        Debug.Log(www.text);
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(Login(inputUsername, inputPassword));
        }
        

        
    }

    public void OnLogin()
    {
        StartCoroutine(Login(inputUsername, inputPassword));
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
