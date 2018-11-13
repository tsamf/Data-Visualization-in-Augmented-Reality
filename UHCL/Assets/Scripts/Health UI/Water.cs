using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Water : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image objW;
  
    public FlagStore commonData;
    public ColorCode cc;
    public BL_Main bl_main;


    
    void Start () {
        commonData = FlagStore.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {


        radius = (bl_main.bl_scaling.scallingWater()) / 100;




        if(commonData.WaterLoDB < commonData.WaterValue)
        {
            //   Debug.Log("H");
            cc.HCol();
            objW.color = cc.HColor;
            objW.transform.localScale = new Vector3(radius, radius, 1.0f);
        }
        else if (commonData.WaterLoDB > commonData.WaterValue && commonData.WaterValue > commonData.WaterLoLoDB)
        {
            // Debug.Log("L");
            cc.LCol();
            objW.color = cc.LColor;
            objW.transform.localScale = new Vector3(radius, radius, 1.0f);
        }

        else if (commonData.WaterLoLoDB > commonData.WaterValue)
        {
            //Debug.Log("LL");
             cc.LLCol();
            objW.color = cc.LLColor; 
        }    
    }
}

