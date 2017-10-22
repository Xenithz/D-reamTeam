using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTOfflineGameManager : GameManager
{
    public BTBombAssigner myAssigner;
    public BTBomb myBomb;

    private void Start()
    {
        myAssigner.RandomizeAndAssign();
    }

    private void Update()
    {

    }
}
