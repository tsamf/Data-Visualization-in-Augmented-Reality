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
    public Text WarningText;
        public GameObject singleWarningDisplay;


	// Use this for initialization
	void Start () {

       // warningDetailPanel.SetActive(true);
        singleWarningDisplay.SetActive(false);
	}



    // Update is called once per frame
    void Update()
    {
       if (bl_main.GetComponent<BL_Main>().bl_alarming.GetCurrentAlarm != null)
       {
       
            singleWarningDisplay.SetActive(true);
            currentwarning.text = bl_main.GetComponent<BL_Main>().bl_alarming.GetCurrentAlarm.message;
            WarningText.text = bl_main.GetComponent<BL_Main>().bl_alarming.GetCurrentAlarm.message;
        }
        else
        {
            singleWarningDisplay.SetActive(false);
            currentwarning.text = "";
            WarningText.text = "";
        }

        if (bl_main.GetComponent<BL_Main>().bl_alarming.GetPerviousAlarm != null)
        {
   
        prevwarning.text = bl_main.GetComponent<BL_Main>().bl_alarming.GetPerviousAlarm.message;
        }
        else
        {
            prevwarning.text = "";
        }
       if (bl_main.GetComponent<BL_Main>().bl_alarming.GetNextAlarm != null)
        {
         
            nextwarning.text = bl_main.GetComponent<BL_Main>().bl_alarming.GetNextAlarm.message;
        }
       else
        {
            nextwarning.text = "";
        }
    }
}

