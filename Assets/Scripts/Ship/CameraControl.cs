using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera RCam;
    public Camera LCam;
    public Camera MainCamera;
    void Start()
    {
        MainCamera.enabled = true;
        RCam.enabled = false;
        LCam.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            MainCamera.enabled = true;
            RCam.enabled = false;
            LCam.enabled = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            MainCamera.enabled = false;
            RCam.enabled = false;
            LCam.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            MainCamera.enabled = false;
            RCam.enabled = true;
            LCam.enabled = false;
        }
        
    }
}
