using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Pressure : MonoBehaviour {

    // Use this for initialization

    public float radius = 100.0f;
    public Image objP;
    public float actualP;
    public CommonData commonData;
    public EmergencyWindow ewindow;
   
    public ColorCode cc;

    public GameObject bl_main;

    // public Color HHColor = new Color(0.39f, 0.58f, 0.93f, 1.0f);
    void Start () {
        commonData = CommonData.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

        radius = bl_main.GetComponent<BL_Main>().bl_scaling.ScalingFunction();
        actualP = bl_main.GetComponent<BL_Main>().bl_scaling.actualSuitPressure();
        if (radius >= 80.00)
        {
            cc.LLCol();
            objP.color = cc.LLColor;
        }
        else if (79.99f >= radius && radius >= 71.00f)
        {
            cc.LCol();
            objP.color = cc.LColor;
        }
        else if (70.99 >= radius && radius >= 41.00f)
        {
            cc.HCol();
            objP.color = cc.HColor;
        }
        else if (40.99f >= radius && radius >= 21.00f)
        {
            cc.LCol();
            objP.color = cc.LColor;
        }
        else if (20.99f >= radius && radius >= 0.01f)
        {
            cc.LLCol();
            objP.color = cc.LLColor;
            ewindow.Show("Suit Pressure Low. Return Back to the Ship." + '\n' +
               "Pressure:" + actualP);
        }

        else
            Debug.Log(" unable to record pressure Error");


        if (commonData.SuitPressureValue >= 0.009f)
            objP.transform.localScale = new Vector3(radius/100, radius/100, 1.0f);


    }
}
