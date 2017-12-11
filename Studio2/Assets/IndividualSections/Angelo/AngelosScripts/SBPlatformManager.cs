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
    public MeshRenderer platform1Renderer, platform2Renderer, platform3Renderer;
    public Material platform1Material, platform2Material, platform3Material;

    public GameObject platform;

    public GameObject platform1, platform2, platform3;
    public Vector3 platform1FinalScale, platform2FinalScale, platform3FinalScale;

    public bool isReadyToSwitch;
    public Color myColor;

    

    void Update()
    {

        if (currentPhase == PlatformPhases.Phase1 && isReadyToSwitch == false)
        {
            ShrinkNoPlat(platform1FinalScale);
            
        }

        if (isReadyToSwitch == true && currentPhase == PlatformPhases.Phase1)
        {
            Timer(PlatformPhases.Phase2);
            ColorLerp(platform2Material);
        }

        if (currentPhase == PlatformPhases.Phase2 && isReadyToSwitch == false)
        {
            Shrink(platform2FinalScale, platform2);
        }

        if (isReadyToSwitch == true && currentPhase == PlatformPhases.Phase2)
        {
            Timer(PlatformPhases.Phase3);
            ColorLerp(platform3Material);
        }

        if (currentPhase == PlatformPhases.Phase3 && isReadyToSwitch == false)
        {
            Shrink(platform3FinalScale, platform3);
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

        platform1FinalScale = platform1.transform.localScale;
        platform2FinalScale = platform2.transform.localScale;
        platform3FinalScale = platform3.transform.localScale;
        platform1Renderer = GetComponent<MeshRenderer>();
        platform1Material = platform1Renderer.materials[1];
        platform2Renderer = platform2.GetComponent<MeshRenderer>();
        platform2Material = platform2Renderer.materials[1];
        platform3Renderer = platform3.GetComponent<MeshRenderer>();
        platform3Material = platform3Renderer.materials[1];
        myColor = new Color(0, 165, 251, 255);
    }

    public void ColorLerp(Material materialToLerp)
    {
        materialToLerp.color = Color.Lerp(myColor, Color.red, Mathf.PingPong(Time.time, 1));
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

    
    public void Shrink(Vector3 scaleToShrinkTo, GameObject platformToDisable)
    {
        platform.transform.localScale = scaleToShrinkTo;
        platformToDisable.SetActive(false);
        if(platform.transform.localScale == scaleToShrinkTo)
        {
            isReadyToSwitch = true;
        }
    }

    public void ShrinkNoPlat(Vector3 scaleToShrinkTo)
    {
        platform.transform.localScale = scaleToShrinkTo;
        if (platform.transform.localScale == scaleToShrinkTo)
        {
            platform1.SetActive(false);
            isReadyToSwitch = true;
        }
    }
}
