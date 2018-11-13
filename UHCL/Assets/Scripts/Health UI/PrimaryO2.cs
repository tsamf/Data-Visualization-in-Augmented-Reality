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
    public BL_Main bl_main;
    public ColorCode ccPO;

    public FlagStore commonData = FlagStore.GetInstance();

    void Start () {
     
    }
	
	void Update () {
        float scaledValue = bl_main.GetComponent<BL_Main>().bl_scaling.scallingPrimaryOxygen();

        radius = scaledValue;


        if (commonData.OxygenOneValue > commonData.PrimaryOxygenLoDB)
        { // Debug.Log("H");
            ccPO.HCol();
            obj.color = ccPO.HColor;
            obj.transform.localScale = new Vector3(radius / 100, radius / 100, 1.0f);
        }
        else if (commonData.OxygenOneValue <= commonData.PrimaryOxygenLoDB)
        {  //  Debug.Log("L");
            ccPO.LCol();
            obj.color = ccPO.LColor;
        }
    }
}
