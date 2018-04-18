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
    void Update()
    {
        //if (bl_main.bl_alarming.CurrentAlarm != null)
        //{
        //    Debug.Log("Current Warning");
        //    currentwarning.text = bl_main.bl_alarming.CurrentAlarm.message;
        //}

        //if (bl_main.bl_alarming.PreviousAlarm != null)
        //{
        //    Debug.Log("Previous Warning");
        //    previouswarning.text = bl_main.bl_alarming.PreviousAlarm.message;
        //}
        //if (bl_main.bl_alarming.NextAlarm != null)
        //{
        //    Debug.Log("Next Warning");
        //    nextwarning.text = bl_main.bl_alarming.CurrentAlarm.message;
        //}
    }
}

