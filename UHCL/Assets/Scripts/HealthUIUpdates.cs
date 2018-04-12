using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIUpdates : MonoBehaviour {

    public GameObject detailedPie;
    public GameObject pie;
    public GameObject displayDetails;
    public GameObject DetailPanel;
    public DisplayDetails dd;
    public BL_Main bl_main;
    public Text WarningText;

    CommonData commonData = CommonData.GetInstance();

    // Use this for initialization
    void Start () {
        detailedPie.SetActive(false);
        displayDetails.SetActive(false);
        DetailPanel.SetActive(false);
        WarningText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDetailPiePanel();
        UpdateViewDetails();
        UpdateWarningWindow();
    }

    void UpdateDetailPiePanel()
    {
        if (commonData.viewPieDetails)
        {
            detailedPie.SetActive(true);
            pie.SetActive(false);
        }
       else if (commonData.closePieDetails)
        {
            
            detailedPie.SetActive(false);
            pie.SetActive(true);
        }
    }

    void UpdateViewDetails()
    {
        if(commonData.viewPressure)
        {
            displayDetails.SetActive(true);
            Debug.Log("view Pressure");
            dd.Display("Suit Pressure Details", "Pressure value " + bl_main.GetComponent<BL_Main >().bl_scaling.actualSuitPressure());

        }
        else if (commonData.closeDetailWindow)
        {
            displayDetails.SetActive(false);
            Debug.Log("CLose DEtail");
        }
    }

    void UpdateWarningWindow()
    {
        if(commonData.viewWarnings)
        {
            DetailPanel.SetActive(true);
            WarningText.text = "Pressure Low";
           
        }
        else if(commonData.closeWarnings)
        {
            DetailPanel.SetActive(false);
            WarningText.text = "";
        }
    }
}
