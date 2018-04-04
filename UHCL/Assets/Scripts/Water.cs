using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Water : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image objW;
    public float currentW;



    
    void Start () {
        currentW = (Console.Read());
    }
	
	// Update is called once per frame
	void Update () {
        

        radius = currentW;
      

        if (currentW >= 0.80)
        {
            Debug.Log("HH");
            objW.color = Color.blue;
        }
        else if (0.79f >= currentW && currentW >= 0.50f)
        {
            Debug.Log("H");
            objW.color = Color.green;
        }
        else if (0.49 >= currentW && currentW >= 0.25f)
        {
            Debug.Log("L");
            objW.color = Color.yellow;
        }

        else if (0.24 >= currentW && currentW >= 0.01f)
        {
            Debug.Log("LL");
            objW.color = Color.red;
        }

        else
            Debug.Log("Battery Error");


        if (currentW >= 0.009f)
            objW.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

