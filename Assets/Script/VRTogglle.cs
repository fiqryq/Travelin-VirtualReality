// Run in split-screen mode
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VRTogglle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadDevice("Split"));
    }

    // void Update(){
    // 	if (Input.GetMouseButtonDown(0)){
    // 		ToggleVR();
    // 	}

    // void ToggleVR(){
    // 	if (XRSettings.loadedDeviceName == "cardboard"){
    // 		StartCoroutine(LoadDevice("None"));
    // 	} else {
    // 		StartCoroutine(LoadDevice("cardboard"));
    // 	}

    IEnumerator LoadDevice(string newDevice)
    {
        if (String.Compare(XRSettings.loadedDeviceName, newDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;
        }
    }
}
