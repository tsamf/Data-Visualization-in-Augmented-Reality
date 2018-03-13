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
    public GameObject busLayer;
    private BL_Main pressurelog;

    void Start () {
        //Assign max value to cuurent health status for initialization
       // currentHealth = (Console.Read());

        //Attach the pressurelog from the buslayer if the buslayer was assigned in the editor
        if (busLayer != null)
        {
            pressurelog = busLayer.GetComponent<BL_Main>();
        }
        //If not attached in the editor find one in the current scene
        else
        {
            busLayer = GameObject.FindGameObjectWithTag("Bus Layer");
            pressurelog = busLayer.GetComponent<BL_Main>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        radius = currentHealth;


        if (currentHealth >= 0.5)
            Debug.Log("HH");

        else if (0.49f >= currentHealth && currentHealth >= 0.31f)
            Debug.Log("H");

        else if (0.30 >= currentHealth && currentHealth >= 0.21f)
            Debug.Log("L");

        else if (currentHealth >= 0.20f)
            Debug.Log("LL");

        else
            Debug.Log("Error");


        if (currentHealth >= 0.05f)
            obj.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}
