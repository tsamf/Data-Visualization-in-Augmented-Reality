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
        if (commonData.viewPressure)
        {
            displayDetails.SetActive(true);
            Debug.Log("view Pressure");
            dd.Display("Suit Pressure Details", "Pressure value " + bl_main.GetComponent<BL_Main>().bl_scaling.actualSuitPressure() + "PSI" + '\n' + '\n' + "Primary O2: " + (commonData.OxygenOneValue) + "psi" + '\n' + '\n' + "Secondary O2: " + (commonData.OxygenTwoValue) + "psi");
            commonData.viewPressure = false;
        }
        else if (commonData.viewPrimaryOTwo)
        {
            float Po2 = bl_main.bl_scaling.scallingPrimaryOxygen();
            Po2 = Mathf.Round(Po2 * 100f) / 100; ;
            displayDetails.SetActive(true);
            dd.Display("Primary Oxygen Details", "Primary O2 left: " + Po2 + "%" + '\n' + '\n' + "Primary O2: " + (commonData.OxygenOneValue) + "psi");
            commonData.viewPrimaryOTwo = false;
        }

        else if (commonData.viewSecondaryOTwo)
        {
            float So2 = bl_main.bl_scaling.scallingSeondaryOxygen();
            So2 = Mathf.Round(So2 * 100f) / 100;
            displayDetails.SetActive(true);
            dd.Display("Secondary Oxygen Details", "Secondary O2 left: " + So2 + "%" + '\n' + '\n' + "Secondary O2: " + (commonData.OxygenTwoValue) + "psi");
            commonData.viewSecondaryOTwo = false;
        }

        else if (commonData.viewBattery)
        {
            float bat = bl_main.bl_scaling.scallingBattery();
            bat = Mathf.Round(bat * 100f) / 100;
            displayDetails.SetActive(true);
            dd.Display("Battery Details", "Battery left: " + bat + "%");
            commonData.viewBattery = false;
        }

        else if (commonData.viewBodyTemperature)
        {
            displayDetails.SetActive(true);
            dd.Display("Temperature Details", "Body Temperature: " + (bl_main.bl_scaling.scallingBodyTemperature()) + " F");
            commonData.viewBodyTemperature = false;
        }

        else if (commonData.viewHeartRate)
        {
            displayDetails.SetActive(true);
            dd.Display("Heart Details", "Heart Rate: " + (bl_main.bl_scaling.scallingHeartRate()) + " bpm");
            commonData.viewHeartRate = false;
        }
        else if (commonData.viewHTwoO)
        {

            float water = bl_main.bl_scaling.scallingWater();
            water = Mathf.Round(water * 100f) / 100;
            displayDetails.SetActive(true);
            dd.Display("H2O Details", "H2O left: " + water + "%" + '\n' + '\n' + "H2O :" + commonData.WaterValue + " lbs");
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
