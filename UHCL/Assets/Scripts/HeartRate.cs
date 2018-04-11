using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HeartRate : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image objHR;
    public float currentHeart;
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        radius = currentHeart;


        if (currentHeart >= 0.80)
        {
           // Debug.Log("HH");
            objHR.color = Color.red;
        }
        else if (0.79f >= currentHeart && currentHeart >= 0.61f)
        {
           // Debug.Log("H");
            objHR.color = Color.yellow;
        }
        else if (0.60 >= currentHeart && currentHeart >= 0.41f)
        {
           // Debug.Log("Ideal");
            objHR.color = Color.green;
        }
        else if (0.40f >= currentHeart && currentHeart >= 0.21f)
        {
            //Debug.Log("L");
            objHR.color = Color.yellow;
        }
        else if (0.20f >= currentHeart && currentHeart >= 0.01f)
        {
           // Debug.Log("LL");
            objHR.color = Color.red;
        }

        else
           // Debug.Log(" unable to record heart Rate Error");


        if (currentHeart >= 0.009f)
            objHR.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

