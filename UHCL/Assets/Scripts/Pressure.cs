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
    public CommonData commonData = CommonData.GetInstance();
    public EmergencyWindow ewindow;

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        radius = commonData.SuitPressureValue;


        if (commonData.SuitPressureValue >= 0.80)
        {
            Debug.Log("HH");
            objP.color = Color.red;
        }
        else if (0.79f >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.61f)
        {
            Debug.Log("H");
            objP.color = Color.yellow;
        }
        else if (0.60 >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.41f)
        {
            Debug.Log("Ideal");
            objP.color = Color.green;
        }
        else if (0.40f >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.21f)
        {
            Debug.Log("L");
            objP.color = Color.yellow;
        }
        else if (0.20f >= commonData.SuitPressureValue && commonData.SuitPressureValue >= 0.01f)
        {
            Debug.Log("LL");
            objP.color = Color.red;
            ewindow.Show("Suit Pressure Low. Return Back to the Ship."+ 
               "Pressure:" + commonData.SuitPressureValue);
        }

        else
            Debug.Log(" unable to record pressure Error");


        if (commonData.SuitPressureValue >= 0.009f)
            objP.transform.localScale = new Vector3(radius, radius, 1.0f);


    }
}
