using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTOfflineGameManager : GameManager
{
    public BTBombAssigner myAssigner;

    private void Start()
    {
        myAssigner.RandomizeAndAssign();
    }

    private void Update()
    {
        
    }
}
