using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Pressure : MonoBehaviour {

    // Use this for initialization

    public float radius = 100.0f;
    public Image objP;
    public float suitPressure;
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
        suitPressure = commonData.SuitPressureValue;

        if (suitPressure >= commonData.SuitPressHiHiDB && suitPressure <= commonData.SuitPressHiHiSP)
        {
            cc.LLCol();
            objP.color = cc.LLColor;
        }
        else if (suitPressure >= commonData.SuitPressHiDB && suitPressure <= commonData.SuitPressHiSP)
        {
            cc.LCol();
            objP.color = cc.LColor;
        }
        else if (suitPressure <= commonData.SuitPressHiDB && suitPressure >= commonData.SuitPressLoDB)
        {
            cc.HCol();
            objP.color = cc.HColor;
        }
        else if (suitPressure >= commonData.SuitPressLoSP && suitPressure <= commonData.SuitPressLoDB)
        {
            cc.LCol();
            objP.color = cc.LColor;
        }
        else if (suitPressure >= commonData.SuitPressLoLoSP && suitPressure <= commonData.SuitPressLoLoDB)
        {
            cc.LLCol();
            objP.color = cc.LLColor;
          //ewindow.Show("Suit Pressure Low. Return Back to the Ship." + '\n' +
          //    "Pressure:" + actualP);
        }


        
            objP.transform.localScale = new Vector3(radius/100, radius/100, 1.0f);


    }
}
