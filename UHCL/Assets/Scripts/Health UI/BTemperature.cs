using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BTemperature : MonoBehaviour {

    // Use this for initialization

    public float radius = 1.0f;
    public Image objBT;
    public float bodyTemperature;
    public ColorCode cc;
    public GameObject bl_main;
    public FlagStore commonData;
    void Start () {
        commonData = FlagStore.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {

        bodyTemperature = commonData.BodyTemperatureValue;
       radius = bl_main.GetComponent<BL_Main>().bl_scaling.scallingBodyTemperature();
       


        if (bodyTemperature >= commonData.BodyTemperatureHiHiDB && bodyTemperature <= commonData.BodyTemperatureHiHiSP)
        {
            // Debug.Log("HH");
            cc.LLCol();
            objBT.color = cc.LLColor;
        }
        else if (bodyTemperature >= commonData.BodyTemperatureHiDB && bodyTemperature <= commonData.BodyTemperatureHiSP)
        {
            // Debug.Log("H");
            cc.LCol();
            objBT.color = cc.LColor;
            objBT.transform.localScale = new Vector3(radius / 100, radius / 100, 1.0f);
        }
        else if (bodyTemperature <= commonData.BodyTemperatureHiDB && bodyTemperature >= commonData.BodyTemperatureLoDB)
        {
            //  Debug.Log("Ideal");
            cc.HCol();
            objBT.color = cc.HColor;
            objBT.transform.localScale = new Vector3(radius / 100, radius / 100, 1.0f);
        }
        else if (bodyTemperature >= commonData.BodyTemperatureLoSP && bodyTemperature <= commonData.BodyTemperatureLoDB)
        {
            //   Debug.Log("L");
            cc.LCol();
            objBT.color = cc.LColor;
            objBT.transform.localScale = new Vector3(radius / 100, radius / 100, 1.0f);
        }
        else if (bodyTemperature >= commonData.BodyTemperatureLoLoSP && bodyTemperature <= commonData.BodyTemperatureLoLoDB)
        {
            // Debug.Log("LL");
            cc.LLCol();
            objBT.color = cc.LLColor;
        }
    }
}
