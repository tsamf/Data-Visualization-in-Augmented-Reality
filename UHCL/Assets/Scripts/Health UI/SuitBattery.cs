using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SuitBattery : MonoBehaviour
{

    // Use this for initialization
    public float radius;
    public Image objB;
 
    public FlagStore commonData;
    public ColorCode cc;
    public BL_Main bl_main;
    void Start()
    {
        commonData = FlagStore.GetInstance();
        //Assign max value to current health status for initialization
    }

    // Update is called once per frame
    void Update()
    {
        radius = bl_main.bl_scaling.scallingBattery();
       

        if (commonData.BatteryValue > commonData.BatteryLoDB)
        {
            //  Debug.Log("HH");
            cc.HCol();
            objB.color = cc.HColor;
            objB.transform.localScale = new Vector3(radius / 100, radius / 100, 1.0f);
        }
       
        else if (commonData.BatteryLoDB > commonData.BatteryValue && commonData.BatteryValue > commonData.BatteryLoLoDB)
        {
            // Debug.Log("L");
            cc.LCol();
            objB.color = cc.LColor;
            objB.transform.localScale = new Vector3(radius / 100, radius / 100, 1.0f);
        }

        else if (commonData.BatteryLoLoDB > commonData.BatteryValue)
        {
            //  Debug.Log("LL");
            cc.LLCol();
            objB.color = cc.LLColor;
        }
    }
}

