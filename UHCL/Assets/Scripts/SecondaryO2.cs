using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SecondaryO2 : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image objSO2;
    public float currentSO2;

    void Start () {
        //Assign max value to cuurent health status for initialization

    }
	
	// Update is called once per frame
	void Update () {
        
            radius = currentSO2;


            if (currentSO2 >= 0.80)
            {
                Debug.Log("HH");
                objSO2.color = Color.blue;
            }
            else if (0.79f >= currentSO2 && currentSO2 >= 0.50f)
            {
                Debug.Log("H");
                objSO2.color = Color.green;
            }
            else if (0.49 >= currentSO2 && currentSO2 >= 0.25f)
            {
                Debug.Log("L");
                objSO2.color = Color.yellow;
            }

            else if (0.24 >= currentSO2 && currentSO2 >= 0.01f)
            {
                Debug.Log("LL");
                objSO2.color = Color.red;
            }
     
            else
                Debug.Log("Secondary O2 Error");


            if (currentSO2 >= 0.009f)
                objSO2.transform.localScale = new Vector3(radius, radius, 1.0f);
        }
}
