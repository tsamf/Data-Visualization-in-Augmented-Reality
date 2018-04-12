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
   //private BL_Main pressurelog;
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
        float normalizedOxygen = commonData.OxygenOneValue;

        radius = normalizedOxygen;


        if (normalizedOxygen >= 50.00f)
        {  //  Debug.Log("HH");
            ccPO.HHCol();
            obj.color = ccPO.HHColor;
        }
        else if (49.99f >= normalizedOxygen && normalizedOxygen >= 31.00f)
        { // Debug.Log("H");
            ccPO.HCol();
            obj.color = ccPO.HColor;
        }
        else if (30.99 >= normalizedOxygen && normalizedOxygen >= 21.00f)
        {  //  Debug.Log("L");
            ccPO.HCol();
            obj.color = ccPO.HColor;
        }
        else if (20.99f >= normalizedOxygen )
        { //  Debug.Log("LL");
            ccPO.LCol();
            obj.color = ccPO.LColor;
        }

      //  else
        // Debug.Log("Error");



        if (normalizedOxygen >= 0.009f)
            obj.transform.localScale = new Vector3(radius/100, radius/100, 1.0f);
    }
}
