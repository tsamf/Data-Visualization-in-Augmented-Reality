using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUI_WarningWindow : MonoBehaviour {

    public BL_Main bl_main;
    public GameObject warningDetailPanel;
    public Text previouswarning;
    public Text currentwarning;
    public Text nextwarning;
   


	// Use this for initialization
	void Start () {

        warningDetailPanel.SetActive(true);
        
	}
	
	// Update is called once per frame
	void Update () {
      for (int i = 1; i<= bl_main.bl_alarming.alarmList.Count ; i++)
        {
            previouswarning.text = bl_main.bl_alarming.alarmList[i-1].message;
            Debug.Log("Previous WArning");
            currentwarning.text = bl_main.bl_alarming.alarmList[i].message;
            nextwarning.text = bl_main.bl_alarming.alarmList[i+1].message;
        }
		
	}
}
