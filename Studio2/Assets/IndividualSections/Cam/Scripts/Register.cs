using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI; 
using UnityEngine;


public class Register : PunBehaviour {


    public string userUrl;
    public string inputUserName;
    public string inputPassword;
    public string inputEmail;
    public string inputConfirm;
 

    public int UserID;

    public Text userTextField;
    public Text passwordTextField;
    public Text emailTextField;
    public Text passwordConfirmField;


    public GameObject logIn;
    public GameObject register;


	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

    
    void Start()
    {
        userUrl = "https://cosmicchaos.000webhostapp.com/network/register.php";
    }

    public IEnumerator CreateUser(string username, string password, string email)
    {
        WWWForm userForm = new WWWForm();
        userForm.AddField("usernamePost", username);
        userForm.AddField("passwordPost", password);
        userForm.AddField("emailPost", email);

        WWW registerURL = new WWW(userUrl, userForm);

        yield return registerURL;
        Debug.Log(registerURL.text);
        register.SetActive(false);
        logIn.SetActive(true);

    }


    public void OnClickRegister()
    {


        inputUserName = userTextField.text.ToString();
        inputPassword = passwordTextField.text.ToString();
        inputEmail = emailTextField.text.ToString();
        inputConfirm = passwordConfirmField.text.ToString();

        CheckPassword();


    }

    public void CheckPassword()
    {

        if (inputPassword == inputConfirm)
        {
            StartCoroutine(CreateUser(inputUserName, inputPassword, inputEmail));
            Debug.Log("starting register");
        }

        else
        {
            Debug.Log("Passwords do not match");

        }
    }

}
