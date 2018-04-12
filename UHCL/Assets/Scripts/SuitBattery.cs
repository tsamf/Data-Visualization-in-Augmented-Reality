using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SuitBattery : MonoBehaviour
{

    // Use this for initialization
    public float radius = 1.0f;
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
        radius = (commanData.BatteryValue)/100;
        currentBatt = radius;

        if (currentBatt >= 0.80f)
        {
            //  Debug.Log("HH");
            cc.HHCol();
            objB.color = cc.HHColor;
        }
        else if (0.79f >= currentBatt && currentBatt >= 0.50f)
        {
            // Debug.Log("H");
            cc.HCol();
            objB.color = cc.HColor;
        }
        else if (0.49 >= currentBatt && currentBatt >= 0.25f)
        {
            // Debug.Log("L");
            cc.LCol();
            objB.color = cc.LColor;
        }

        else if (0.24 >= currentBatt && currentBatt >= 0.01f)
        {
            //  Debug.Log("LL");
            cc.LLCol();
            objB.color = cc.LLColor;
        }

        else
          //  Debug.Log("Battery Error");


        if (currentBatt >= 0.009f)
            objB.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

