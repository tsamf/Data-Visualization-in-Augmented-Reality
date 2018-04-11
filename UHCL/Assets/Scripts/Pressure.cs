using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Pressure : MonoBehaviour {

    // Use this for initialization

    public float radius = 1.0f;
    public Image objP;
    public float currentP;
    public CommonData commonData;
    public EmergencyWindow ewindow;
    public ColorCode cc;
   
   // public Color HHColor = new Color(0.39f, 0.58f, 0.93f, 1.0f);
    void Start () {
        commonData = CommonData.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {
        radius = commonData.SuitPressureValue;


        if (commonData.SuitPressureValue >= 0.80)
        {
            cc.LLCol();
            objP.color = cc.LLColor;
        }
        else if (0.79f >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.61f)
        {
            cc.LCol();
            objP.color = cc.LColor;
        }
        else if (0.60 >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.41f)
        {
            cc.HCol();
            objP.color = cc.HColor;
        }
        else if (0.40f >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.21f)
        {
            cc.LCol();
            objP.color = cc.LColor;
        }
        else if (0.20f >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.01f)
        {
            cc.LLCol();
            objP.color = cc.LLColor;
            ewindow.Show("Suit Pressure Low. Return Back to the Ship."+ 
               "Pressure:" + commonData.SuitPressureValue);
        }

        else
            Debug.Log(" unable to record pressure Error");


        if (commonData.SuitPressureValue >= 0.009f)
            objP.transform.localScale = new Vector3(radius, radius, 1.0f);


    }
}
