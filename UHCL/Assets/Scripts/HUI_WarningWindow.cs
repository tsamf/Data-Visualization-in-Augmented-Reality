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
<<<<<<< HEAD
        

    //    bl_main.GetComponent<BL_Main>().bl_alarming.BLAlarming();
    //    bool flagL = bl_main.GetComponent<BL_Main>().bl_alarming.SuitPressureLoStatus;

    //    if(flagL == true)
     //   {
     //       Panel.SetActive(true);
      //      warning.color = Color.yellow;
       //     warning.text = "Pressure Low";

       // }
=======
      for (int i = 1; i<= bl_main.bl_alarming.alarmList.Count ; i++)
        {
            previouswarning.text = bl_main.bl_alarming.alarmList[i-1].message;
            Debug.Log("Previous WArning");
            currentwarning.text = bl_main.bl_alarming.alarmList[i].message;
            nextwarning.text = bl_main.bl_alarming.alarmList[i+1].message;
        }
>>>>>>> 47a1cd1bba01340368628765b9b33aecd315c11c
		
	}
}
