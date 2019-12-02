using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VRYesPlease : MonoBehaviour
{

    public void Start(){
        StartCoroutine(ActivatorVR("cardboard"));

    }

    public IEnumerator ActivatorVR(string YESVR){
    	XRSettings.LoadDeviceByName(YESVR);
    	yield return null;
    	XRSettings.enabled = true;
    	
    }

}
