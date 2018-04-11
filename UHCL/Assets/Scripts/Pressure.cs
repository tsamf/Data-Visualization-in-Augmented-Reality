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

    public GameObject bl_main;

    // public Color HHColor = new Color(0.39f, 0.58f, 0.93f, 1.0f);
    void Start () {
        commonData = CommonData.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        radius = bl_main.GetComponent<BL_Main>().bl_scaling.ScalingFunction();

        if (radius >= 0.80)
        {
            Debug.Log("HH");
            objP.color = Color.red;
        }
        else if (0.79f >= radius && radius >= 0.61f)
        {
            Debug.Log("H");
            objP.color = Color.yellow;
        }
        else if (0.60 >= radius && radius >= 0.41f)
        {
            Debug.Log("Ideal");

            objP.color = Color.green;
        }
        else if (0.40f >= radius && radius >= 0.21f)
        {
            Debug.Log("L");
            objP.color = Color.yellow;
        }
        else if (0.20f >= radius && radius >= 0.01f)
        {
            Debug.Log("LL");
            objP.color = Color.red;
            ewindow.Show("Suit Pressure Low. Return Back to the Ship." +
               "Pressure:" + radius);
        }

        else
            Debug.Log(" unable to record pressure Error");


        if (commonData.SuitPressureValue >= 0.009f)
            objP.transform.localScale = new Vector3(radius, radius, 1.0f);


    }
}
