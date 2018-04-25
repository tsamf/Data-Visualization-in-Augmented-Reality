using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn02On : MonoBehaviour {

    CommonData commonData;
    public DB_GenerateData oxygen2;


	// Use this for initialization
	void Start () {
        commonData = CommonData.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		if(commonData.OxygenOneValue < 1)
        {
            oxygen2.isActive = true;
        }
	}
}
