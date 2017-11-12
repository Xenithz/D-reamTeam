using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlatformPhases
{ 
    Phase0,
    Phase1,
    Phase2,
    Phase3
}


public class SBPlatformManager : MonoBehaviour
{
    public float currentTime;
    public float timeBetweenPhases;

    public PlatformPhases currentPhase;


    public GameObject platform;

    public Vector3 platform1FinalScale, platform2FinalScale, platform3FinalScale;

    public bool isReadyToSwitch;

    

    void Update()
    {

        if (currentPhase == PlatformPhases.Phase1 && isReadyToSwitch == false)
        {
            Shrink(platform1FinalScale);
            
        }

        if (isReadyToSwitch == true && currentPhase == PlatformPhases.Phase1)
        {
            Timer(PlatformPhases.Phase2);
        }

        if (currentPhase == PlatformPhases.Phase2 && isReadyToSwitch == false)
        {
            Shrink(platform2FinalScale);
        }

        if (isReadyToSwitch == true && currentPhase == PlatformPhases.Phase2)
        {
            Timer(PlatformPhases.Phase3);
        }

        if (currentPhase == PlatformPhases.Phase3 && isReadyToSwitch == false)
        {
            Shrink(platform3FinalScale);
        }

        if (SumoNetworkManager.Instance.currentGameState == GameStates.InProgress)
        {
           if (currentPhase == PlatformPhases.Phase0)
            { 
                isReadyToSwitch = false;
                currentPhase = PlatformPhases.Phase1;

            }
        }

    }

    void Awake()
    {
        currentTime = timeBetweenPhases;

        currentPhase = PlatformPhases.Phase0;
        //isReadyToSwitch = false;

    }

    public void Timer(PlatformPhases platformPhaseToSwitchTo)
    {
        currentTime -= Time.deltaTime;
        if (0 >= currentTime)
        {
            currentTime = timeBetweenPhases;
            currentPhase = platformPhaseToSwitchTo;
            isReadyToSwitch = false;
        }
    }

    
    public void Shrink(Vector3 scaleToShrinkTo)
    {
        platform.transform.localScale = Vector3.Lerp(platform.transform.localScale, scaleToShrinkTo, Time.deltaTime);

        if(platform.transform.localScale == scaleToShrinkTo)
        {
            isReadyToSwitch = true;
        }
    }
}
