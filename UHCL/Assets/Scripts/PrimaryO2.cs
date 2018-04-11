using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrimaryO2 : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image obj;
    public float currentHealth;
   // public GameObject busLayer;
   // private BL_Main pressurelog;
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
        float normalizedOxygen = commonData.OxygenOneValue / 100;

        radius = normalizedOxygen;


        if (normalizedOxygen >= 0.5)
        {  //  Debug.Log("HH");
            ccPO.HHCol();
            obj.color = ccPO.HHColor;
        }
        else if (0.499f >= normalizedOxygen && normalizedOxygen >= 0.31f)
        { // Debug.Log("H");
            ccPO.HCol();
            obj.color = ccPO.HColor;
        }
        else if (0.3099 >= normalizedOxygen && normalizedOxygen >= 0.21f)
        {  //  Debug.Log("L");
            ccPO.HCol();
            obj.color = ccPO.HColor;
        }
        else if (0.2099f >= normalizedOxygen )
        { //  Debug.Log("LL");
            ccPO.LCol();
            obj.color = ccPO.LColor;
        }

      //  else
        // Debug.Log("Error");



        if (normalizedOxygen >= 0.05f)
            obj.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}
