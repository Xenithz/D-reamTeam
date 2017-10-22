using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTUIManager : MonoBehaviour
{
    public Text myCountDown;
    public Text mySwitchCooldown;
    public BTBomb myBomb;

    private void Update()
    {
        UpdateMyCountDown();
        //UpdateSwitchCooldown();
    }

    private void UpdateMyCountDown()
    {
        myCountDown.text = myBomb.currentTimeTillExplosion.ToString();
    }

    private void UpdateSwitchCooldown()
    {
        mySwitchCooldown.text = myBomb.currentTimeTillCanSwitch.ToString();
    }
}
