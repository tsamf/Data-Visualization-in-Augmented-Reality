using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUI_WarningWindow : MonoBehaviour {

    public GameObject bl_main;
    public GameObject warningDetailPanel;
    public Text prevwarning;
    public Text currentwarning;
    public Text nextwarning;
  


	// Use this for initialization
	void Start () {

        warningDetailPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

    //    bl_main.GetComponent<BL_Main>().bl_alarming.BLAlarming();
    //    bool flagL = bl_main.GetComponent<BL_Main>().bl_alarming.SuitPressureLoStatus;

    //    if(flagL == true)
     //   {
     //       Panel.SetActive(true);
      //      warning.color = Color.yellow;
       //     warning.text = "Pressure Low";

       // }
		
	}
}
