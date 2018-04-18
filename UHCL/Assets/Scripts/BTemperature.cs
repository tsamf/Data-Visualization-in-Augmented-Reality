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
    public ColorCode cc;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        currentBT = 0.59f;
        radius = currentBT;


        if (currentBT >= 0.80)
        {
            // Debug.Log("HH");
            cc.LLCol();
            objBT.color = cc.LLColor;
        }
        else if (0.79f >= currentBT && currentBT >= 0.61f)
        {
            // Debug.Log("H");
            cc.LCol();
            objBT.color = cc.LColor;
        }
        else if (0.60 >= currentBT && currentBT >= 0.41f)
        {
            //  Debug.Log("Ideal");
            cc.HCol();
            objBT.color = cc.HColor;
        }
        else if (0.40f >= currentBT && currentBT >= 0.21f)
        {
            //   Debug.Log("L");
            cc.LCol();
            objBT.color = cc.LColor;
        }
        else if (0.20f >= currentBT && currentBT >= 0.01f)
        {
            // Debug.Log("LL");
            cc.LLCol();
            objBT.color = cc.LLColor;
        }

        else
        {// Debug.Log(" unable to record heart Rate Error");
        }

        if (currentBT >= 0.009f)
            objBT.transform.localScale = new Vector3(radius, radius, 1.0f);

    }
}
