
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalPlayerInfo : MonoBehaviour {

    // Use this for initialization
    //this script will be present on all scenes, will store all users usernames on log in.
    //will also store score and carry over score from different game modes.
   
    public string localPlayerName;
    public int localPlayerScore; 
   
    

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
