using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrimaryO2 : MonoBehaviour {

    // Use this for initialization
    public float radius = 100.0f;
    public Image obj;
    public float currentHealth;
    // public GameObject busLayer;
    public GameObject bl_main;
    public ColorCode ccPO;

    public CommonData commonData = CommonData.GetInstance();

    void Start () {
        //Assign max value to cuurent health status for initialization
       // currentHealth = (Console.Read());

        //Attach the pressurelog from the buslayer if the buslayer was assigned in the editor
      /*  if (busLayer != null)
        {
            pressurelog = busLayer.GetComponent<BL_Main>();
        }
        //If not attached in the editor find one in the current scene
        else
        {
            busLayer = GameObject.FindGameObjectWithTag("Bus Layer");
            pressurelog = busLayer.GetComponent<BL_Main>();
        }*/
    }
	
	// Update is called once per frame
	void Update () {
        float scaledValue = bl_main.GetComponent<BL_Main>().bl_scaling.scallingPrimaryOxygen();

        radius = scaledValue;


        if (commonData.OxygenOneValue > commonData.PrimaryOxygenLoDB)
        { // Debug.Log("H");
            ccPO.HCol();
            obj.color = ccPO.HColor;
        }
        else if (commonData.OxygenOneValue <= commonData.PrimaryOxygenLoDB)
        {  //  Debug.Log("L");
            ccPO.LCol();
            obj.color = ccPO.LColor;
        }
       

            obj.transform.localScale = new Vector3(radius/100, radius/100, 1.0f);
    }
}
