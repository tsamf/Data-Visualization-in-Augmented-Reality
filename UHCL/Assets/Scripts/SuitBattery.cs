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
    public float currentBatt;
    public CommonData commanData;
    public ColorCode cc;
    void Start()
    {
        commanData = CommonData.GetInstance();
        //Assign max value to current health status for initialization
    }

    // Update is called once per frame
    void Update()
    {
        radius = commanData.BatteryValue;
        currentBatt = radius;

        if (currentBatt >= 80.00f)
        {
            //  Debug.Log("HH");
            cc.HHCol();
            objB.color = cc.HHColor;
        }
        else if (79.99f >= currentBatt && currentBatt >= 50.00f)
        {
            // Debug.Log("H");
            cc.HCol();
            objB.color = cc.HColor;
        }
        else if (49.99 >= currentBatt && currentBatt >= 25.00f)
        {
            // Debug.Log("L");
            cc.LCol();
            objB.color = cc.LColor;
        }

        else if (24.99 >= currentBatt && currentBatt >= 0.01f)
        {
            //  Debug.Log("LL");
            cc.LLCol();
            objB.color = cc.LLColor;
        }

        else
        { //  Debug.Log("Battery Error");
        }

        if (currentBatt >= 0.009f)
            objB.transform.localScale = new Vector3(radius/100, radius/100, 1.0f);
    }
}

