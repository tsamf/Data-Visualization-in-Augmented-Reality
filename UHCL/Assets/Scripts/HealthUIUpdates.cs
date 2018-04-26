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
    public GameObject ewindow;

    CommonData commonData = CommonData.GetInstance();

   
    // Use this for initialization
    void Start () {
        detailedPie.SetActive(false);
        displayDetails.SetActive(false);
        DetailPanel.SetActive(false);
       
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDetailPiePanel();
        UpdateViewDetails();
        UpdateWarningWindow();
        updateEmergencyMessage();
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
        else if (commonData.viewPrimaryOTwo)
        {
            displayDetails.SetActive(true);
            dd.Display("Primary Oxygen Details", "Primary O2 left: " + (commonData.OxygenOneValue) + "%");
        }

        else if (commonData.viewSecondaryOTwo)
        {
            displayDetails.SetActive(true);
            dd.Display("Secondary Oxygen Details", "Secondary O2 left: " + (commonData.OxygenTwoValue) + "%");
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
     
       
           commonData.viewWarnings = false;
        }
        else if(commonData.closeWarnings)
        {
            DetailPanel.SetActive(false);
             commonData.closeWarnings = false;
        }
    }

    void updateEmergencyMessage()
    {
        if ((commonData.SuitPressureValue >= commonData.SuitPressHiHiDB && commonData.SuitPressureValue <= commonData.SuitPressHiHiSP) || (commonData.SuitPressureValue >= commonData.SuitPressLoLoSP && commonData.SuitPressureValue <= commonData.SuitPressLoLoDB))
        {

            ewindow.SetActive(true);
            ewindow.GetComponent<EmergencyWindow>().Show("Suit Pressure Low. Return Back to the Ship." + '\n' +
           "Pressure:" + commonData.SuitPressureValue + "psi");
        }

        if ((commonData.HeartRateValue >= commonData.HeartRateHiHiDB && commonData.HeartRateValue <= commonData.HeartRateHiHiSP) || (commonData.HeartRateValue>= commonData.HeartRateLoLoSP && commonData.HeartRateValue <= commonData.HeartRateLoLoDB))
        {
            ewindow.SetActive(true);
            ewindow.GetComponent<EmergencyWindow>().Show("Heart Rate Abnormal. Return Back to the Ship" + '\n' +
           "Pressure:" + commonData.HeartRateValue + "bpm");
        }

        if ((commonData.BodyTemperatureValue >= commonData.BodyTemperatureHiHiDB && commonData.BodyTemperatureValue <= commonData.BodyTemperatureHiHiSP) || (commonData.BodyTemperatureValue >= commonData.BodyTemperatureLoLoSP && commonData.BodyTemperatureValue <= commonData.BodyTemperatureLoLoDB))
        {
            ewindow.SetActive(true);
            ewindow.GetComponent<EmergencyWindow>().Show("Body Temperature Abnormal. Return Back to the Ship" + '\n' +
           "Body Temperature:" + commonData.BodyTemperatureValue + "F");
        }
    }
}
