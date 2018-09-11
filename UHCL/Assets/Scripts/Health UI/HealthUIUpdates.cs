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

    FlagStore commonData = FlagStore.GetInstance();

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
        //UpdateWarningWindow();
        //updateEmergencyMessage();
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
        if (commonData.viewPressure)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.SuitPressure;
            commonData.viewPressure = false;
        }
        else if (commonData.viewPrimaryOTwo)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.Oxygen;
            commonData.viewPrimaryOTwo = false;
        }
        else if (commonData.viewSecondaryOTwo)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.OxygenTwo;
            commonData.viewSecondaryOTwo = false;
        }

        else if (commonData.viewBattery)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.Battery;
            commonData.viewBattery = false;
        }
        else if (commonData.viewBodyTemperature)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.BodyTemperature;
            commonData.viewBodyTemperature = false;
        }
        else if (commonData.viewHeartRate)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.HeartRate;
            commonData.viewHeartRate = false;
        }
        else if (commonData.viewHTwoO)
        {
            displayDetails.SetActive(true);
            dd.displayingType = displayType.Water;
            commonData.viewHTwoO = false;
        }
        else if (commonData.closeDetailWindow)
        {
            displayDetails.SetActive(false);
            //  Debug.Log("Close DEtail");
            commonData.closeDetailWindow = false;
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

        if (DetailPanel.active)
        {
            if (bl_main.bl_alarming.GetCurrentAlarm == null)
            {
                DetailPanel.SetActive(false);
            }
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

        if ((commonData.HeartRateValue >= commonData.HeartRateHiHiDB && commonData.HeartRateValue <= commonData.HeartRateHiHiSP) || (commonData.HeartRateValue >= commonData.HeartRateLoLoSP && commonData.HeartRateValue <= commonData.HeartRateLoLoDB))
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

      
        
            if (commonData.OxygenTwoValue <= commonData.SecondaryOxygenLoLoDB)
            {
                ewindow.SetActive(true);
                ewindow.GetComponent<EmergencyWindow>().Show("Low Oxygen Levels. Return Back to the Ship" + '\n' +
               "Oxygen:" + bl_main.bl_scaling.scallingSeondaryOxygen() + "%");
            }


        if(commonData.WaterLoLoDB > commonData.WaterValue)
        {
            ewindow.SetActive(true);
            ewindow.GetComponent<EmergencyWindow>().Show("Water Level Low" + '\n' +
           "Water Left:" + commonData.WaterValue + "%");
        }


        if(commonData.BatteryLoLoDB > commonData.BatteryValue)
        {
            ewindow.SetActive(true);
            ewindow.GetComponent<EmergencyWindow>().Show("Suit Battery Low" + '\n' +
           "Battery Left:" + commonData.BatteryValue + "%");
        }
    }
}
