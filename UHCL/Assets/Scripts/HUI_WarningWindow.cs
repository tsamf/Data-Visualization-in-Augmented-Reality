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
<<<<<<< HEAD

    // Update is called once per frame
    void Update()
    {
        if (bl_main.bl_alarming.CurrentAlarm != null)
=======
	
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
>>>>>>> 6d180567f5c5ab5d236a235b447eda60978c163a
        {
            Debug.Log("Current Warning");
            currentwarning.text = bl_main.bl_alarming.CurrentAlarm.message;
        }
<<<<<<< HEAD
        if (bl_main.bl_alarming.PreviousAlarm != null)
        {
            Debug.Log("Previous Warning");
            previouswarning.text = bl_main.bl_alarming.PreviousAlarm.message;
        }
        if (bl_main.bl_alarming.NextAlarm != null)
        {
            Debug.Log("Next Warning");
            nextwarning.text = bl_main.bl_alarming.CurrentAlarm.message;
        }
    }
=======
>>>>>>> 47a1cd1bba01340368628765b9b33aecd315c11c
		
	}
>>>>>>> 6d180567f5c5ab5d236a235b447eda60978c163a
}

