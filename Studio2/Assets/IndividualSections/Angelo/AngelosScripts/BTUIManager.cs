using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTUIManager : MonoBehaviour
{
    public Text myCountDown;
    public Text mySwitchCooldown;
    public BTBomb myBomb;

    private void UpdateMyCountDown()
    {
        myCountDown.text = myBomb.timeTillExplosion.ToString();
    }

    private void UpdateSwitchCooldown()
    {
        mySwitchCooldown.text = myBomb.timeTillSwitch.ToString();
    }
}
