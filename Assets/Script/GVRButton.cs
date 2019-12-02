﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVRButton : MonoBehaviour
{
	public Image imgCircle;
	public UnityEvent GVRClick;
	public float totalTime = 2;
	bool gvrStatus;
	public float gvrTimer;

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus)
        {
        	gvrTimer += Time.deltaTime;
        	imgCircle.fillAmount = gvrTimer / totalTime;
        }

        if(gvrTimer > totalTime)
        {
        	GVRClick.Invoke();
        }
    }

    public void GvrOn()
    {
    	gvrStatus = true;
    }

    public void GvrOff()
    {
    	gvrStatus = false;
    	gvrTimer = 0;
    	imgCircle.fillAmount = 0;
    }
}
