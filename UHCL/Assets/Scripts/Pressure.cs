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
    void Start () {
        currentP = (Console.Read());
    }
	
	// Update is called once per frame
	void Update () {
        radius = currentP;


        if (currentP >= 0.80)
        {
            Debug.Log("HH");
            objP.color = Color.red;
        }
        else if (0.79f >= currentP && currentP >= 0.61f)
        {
            Debug.Log("H");
            objP.color = Color.yellow;
        }
        else if (0.60 >= currentP && currentP >= 0.41f)
        {
            Debug.Log("Ideal");
            objP.color = Color.green;
        }
        else if (0.40f >= currentP && currentP >= 0.21f)
        {
            Debug.Log("L");
            objP.color = Color.yellow;
        }
        else if (0.20f >= currentP && currentP >= 0.01f)
        {
            Debug.Log("LL");
            objP.color = Color.red;
        }

        else
            Debug.Log(" unable to record heart Rate Error");


        if (currentP >= 0.009f)
            objP.transform.localScale = new Vector3(radius, radius, 1.0f);


    }
}
