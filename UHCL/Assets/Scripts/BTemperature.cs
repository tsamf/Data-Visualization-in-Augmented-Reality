using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BTemperature : MonoBehaviour {

    // Use this for initialization

    public float radius = 1.0f;
    public Image objBT;
    public float currentBT;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        radius = currentBT;


        if (currentBT >= 0.80)
        {
           // Debug.Log("HH");
            objBT.color = Color.red;
        }
        else if (0.79f >= currentBT && currentBT >= 0.61f)
        {
           // Debug.Log("H");
            objBT.color = Color.yellow;
        }
        else if (0.60 >= currentBT && currentBT >= 0.41f)
        {
          //  Debug.Log("Ideal");
            objBT.color = Color.green;
        }
        else if (0.40f >= currentBT && currentBT >= 0.21f)
        {
         //   Debug.Log("L");
            objBT.color = Color.yellow;
        }
        else if (0.20f >= currentBT && currentBT >= 0.01f)
        {
           // Debug.Log("LL");
            objBT.color = Color.red;
        }

        else
           // Debug.Log(" unable to record heart Rate Error");


        if (currentBT >= 0.009f)
            objBT.transform.localScale = new Vector3(radius, radius, 1.0f);

    }
}
