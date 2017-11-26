
using UnityEngine;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour {

    public PhotonPlayer PhotonPlayer;
    private Text playerName;


    public void ApplyPhotonPlayer (PhotonPlayer photonPlayer)
    {
        playerName.text = photonPlayer.NickName;
    }


    
}
