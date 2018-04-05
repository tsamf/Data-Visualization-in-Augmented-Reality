using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SuitBattery : MonoBehaviour
{

    // Use this for initialization
    public float radius = 1.0f;
    public Image objB;
    public float currentBatt;

    void Start()
    {

        //Assign max value to current health status for initialization
    }

    // Update is called once per frame
    void Update()
    {
        radius = currentBatt;


        if (currentBatt >= 0.80)
        {
            Debug.Log("HH");
            objB.color = Color.blue;
        }
        else if (0.79f >= currentBatt && currentBatt >= 0.50f)
        {
            Debug.Log("H");
            objB.color = Color.green;
        }
        else if (0.49 >= currentBatt && currentBatt >= 0.25f)
        {
            Debug.Log("L");
            objB.color = Color.yellow;
        }

        else if (0.24 >= currentBatt && currentBatt >= 0.01f)
        {
            Debug.Log("LL");
            objB.color = Color.red;
        }

        else
            Debug.Log("Battery Error");


        if (currentBatt >= 0.009f)
            objB.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

