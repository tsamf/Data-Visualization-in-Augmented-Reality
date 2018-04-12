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
    public ColorCode cc;
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {

        currentHeart = 0.55f;
        radius = currentHeart;

        if (currentHeart >= 0.80f)
        {
            // Debug.Log("HH");
            cc.LLCol();
            objHR.color = cc.LLColor;
        }
        else if (0.79f >= currentHeart && currentHeart >= 0.61f)
        {
            // Debug.Log("H");
            cc.LCol();
            objHR.color = cc.LColor;
        }
        else if (0.60 >= currentHeart && currentHeart >= 0.41f)
        {
            // Debug.Log("Ideal");
            cc.HCol();
            objHR.color = cc.HColor;
        }
        else if (0.40f >= currentHeart && currentHeart >= 0.21f)
        {
            //Debug.Log("L");
            cc.LCol();
            objHR.color = cc.LColor;
        }
        else if (0.20f >= currentHeart && currentHeart >= 0.01f)
        {
            // Debug.Log("LL");
            cc.LLCol();
            objHR.color = cc.LLColor;
        }

        else
        {  // Debug.Log(" unable to record heart Rate Error");
        }

        if (currentHeart >= 0.009f)
            objHR.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

