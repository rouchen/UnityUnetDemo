﻿using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class Memory : MonoBehaviour 
{
    Text memTxt;
    public float updateInterval = 0.5F;
    float lastTimeSinceStartUp;

    StringBuilder stringBuilder = new StringBuilder(128, 128);
    // Use this for initialization
    void Start () 
    {
        lastTimeSinceStartUp = Time.realtimeSinceStartup;
        memTxt = GetComponent<Text>();
        if (memTxt == null)
        {
            Debug.LogError("Text Componenet Not Found !!");
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        float timeleft = Time.realtimeSinceStartup - lastTimeSinceStartUp;

        if (timeleft >= updateInterval)
        {
            stringBuilder.Length = 0;
            stringBuilder.AppendFormat("MEM:{0:F2} KB\n", ((int)((float)Profiler.GetTotalAllocatedMemory() / 1024.0f)).ToString());
            //string format = System.String.Format("MEM:{0:F2} MB", ((int)((float)Profiler.GetTotalAllocatedMemory()/1024.0f/1024.0f)).ToString());
            //memTxt.text = format;
            stringBuilder.AppendFormat("GCT:{0:F2} KB", ((int)((float)GC.GetTotalMemory(true) / 1024.0f)).ToString());

                   

            memTxt.text = stringBuilder.ToString();

            lastTimeSinceStartUp = Time.realtimeSinceStartup;
        }
	}
}
