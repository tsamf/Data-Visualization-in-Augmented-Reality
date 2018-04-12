using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Water : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image objW;
    public float currentW;
    public CommonData commonData;
    public ColorCode cc;


    
    void Start () {
        commonData = CommonData.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {


        radius = commonData.WaterValue/100;
        currentW = radius;

        if (currentW >= 0.80)
        {
            //  Debug.Log("HH");
            cc.HHCol();
            objW.color = cc.HHColor; 
        }
        else if (0.79f >= currentW && currentW >= 0.50f)
        {
            //   Debug.Log("H");
            cc.HCol();
            objW.color = cc.HColor;
        }
        else if (0.49 >= currentW && currentW >= 0.25f)
        {
            // Debug.Log("L");
            cc.LCol();
            objW.color = cc.LColor;
        }

        else if (0.24 >= currentW && currentW >= 0.01f)
        {
            //Debug.Log("LL");
             cc.LLCol();
            objW.color = cc.LLColor; 
        }

        else
        { // Debug.Log("Battery Error");
        }

        if (currentW >= 0.009f)
            objW.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

