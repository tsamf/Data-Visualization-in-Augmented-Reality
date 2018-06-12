using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternativeHealthUIUpdates : MonoBehaviour {

    //public GameObject detailedPie;

    public GameObject displayDetails;
    public GameObject DetailPanel;
    public DisplayDetails dd;
    public BL_Main bl_main;

    public Image pressureFillImage;
    public Image heartRateImage;
    public Image bodyTemperatureImage;

    public Slider PrimaryOxygenSlider;
    public Image PrimaryO2Image;

    public Slider SecondaryOxygenSlider;
    public Image secondaryO2Image;

    public Slider WaterSilder;
    public Image WaterImage;

    public Slider BatterySilder;
    public Image BatteryImage;

    public ColorCode flagColors;

    

    CommonData commonData = CommonData.GetInstance();

    // Use this for initialization
    void Start()
    {
        //detailedPie.SetActive(false);
        
        displayDetails.SetActive(false);
        DetailPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDetailPiePanel();
        UpdateViewDetails();
        UpdateWarningWindow();
        UpdateSliders();
    }

    void UpdateSliders()
    {
        UpdatePressureSlider();
        UpdateHeartRateSlider();
        UpdateBodyTemperature();
        UpdatePrimaryO2();
        UpdateSecondaryO2();
        UpdateWater();
        UpdateBattery();
    }

    private void UpdateBattery()
    {
        BatterySilder.value = bl_main.bl_scaling.scallingBattery() / 100;

        if(commonData.BatteryValue > commonData.BatteryLoDB)
        {
            BatteryImage.color = flagColors.HColor;
        }
        else if(commonData.BatteryLoDB > commonData.BatteryValue && commonData.BatteryValue > commonData.BatteryLoLoDB)
        {
            BatteryImage.color = flagColors.LColor;
        }
        else if(commonData.BatteryLoLoDB > commonData.BatteryValue)
        {
            BatteryImage.color = flagColors.LLColor;
        }
    }

    private void UpdateWater()
    {
        WaterSilder.value = bl_main.bl_scaling.scallingWater() / 100;
        
        if(commonData.WaterLoDB < commonData.WaterValue)
        {
            WaterImage.color = flagColors.HColor;
        }
        else if(commonData.WaterLoDB > commonData.WaterValue && commonData.WaterValue > commonData.WaterLoLoDB)
        {
            WaterImage.color = flagColors.LColor;
        }
        else if(commonData.WaterLoLoDB > commonData.WaterValue)
        {
            WaterImage.color = flagColors.LLColor;
        }
    }

    void UpdatePressureSlider()
    {
        float newPressurePosition = bl_main.bl_scaling.ScalingFunction().Map(0, 100, -66, 68);
        pressureFillImage.rectTransform.localPosition = new Vector3(newPressurePosition, 0f, 0f);

        float SuitPressure = commonData.SuitPressureValue;
        if (SuitPressure >= commonData.SuitPressHiHiDB && SuitPressure <= commonData.SuitPressHiHiSP)
        {
            pressureFillImage.color = flagColors.LLColor;
        }
        else if (SuitPressure >= commonData.SuitPressHiDB && SuitPressure <= commonData.SuitPressHiSP)
        {
            pressureFillImage.color = flagColors.LColor;
        }
        else if(SuitPressure <= commonData.SuitPressHiDB && SuitPressure >= commonData.SuitPressLoDB)
        {
            pressureFillImage.color = flagColors.HColor;
        }
        else if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
        {
            pressureFillImage.color = flagColors.LColor;
        }
        else if (SuitPressure >= commonData.SuitPressLoLoSP && SuitPressure <= commonData.SuitPressLoLoDB)
        {
            pressureFillImage.color = flagColors.LLColor;
        }
    }

    void UpdateHeartRateSlider()
    {
        float newHeartRatePosition = bl_main.bl_scaling.scallingHeartRate().Map(0f, 100f, 12.5f, 148f);
        heartRateImage.rectTransform.localPosition = new Vector3(newHeartRatePosition -80f, 0f, 0f);

        float heartRate = commonData.HeartRateValue;

        if (heartRate >= commonData.HeartRateHiHiDB && heartRate <= commonData.HeartRateHiHiSP)
        {
            heartRateImage.color = flagColors.LLColor;
        }
        else if (heartRate >= commonData.HeartRateHiDB && heartRate <= commonData.HeartRateHiSP)
        {
            heartRateImage.color = flagColors.LColor;
        }
        else if (heartRate <= commonData.HeartRateHiDB && heartRate >= commonData.HeartRateLoDB)
        {
            heartRateImage.color = flagColors.HColor;
        }
        else if (heartRate >= commonData.HeartRateLoSP && heartRate <= commonData.HeartRateLoDB)
        {
            heartRateImage.color = flagColors.LColor;
        }
        else if (heartRate >= commonData.HeartRateLoLoSP && heartRate <= commonData.HeartRateLoLoDB)
        {
            heartRateImage.color = flagColors.LLColor;
        }
    }

    void UpdateBodyTemperature()
    {
        float newBodyTemperaturePosition = bl_main.bl_scaling.scallingBodyTemperature().Map(0f, 100f, 8f, 142f);
        bodyTemperatureImage.rectTransform.localPosition = new Vector3(newBodyTemperaturePosition - 70f, 0f, 0f);

        float bodyTemperature = commonData.BodyTemperatureValue;

        if (bodyTemperature >= commonData.BodyTemperatureHiHiDB && bodyTemperature <= commonData.BodyTemperatureHiHiSP)
        {
            bodyTemperatureImage.color = flagColors.LLColor;
        }
        else if (bodyTemperature >= commonData.BodyTemperatureHiDB && bodyTemperature <= commonData.BodyTemperatureHiSP)
        {
            bodyTemperatureImage.color = flagColors.LColor;
        }
        else if (bodyTemperature <= commonData.BodyTemperatureHiDB && bodyTemperature >= commonData.BodyTemperatureLoDB)
        {
            bodyTemperatureImage.color = flagColors.HColor;
        }
        else if (bodyTemperature >= commonData.BodyTemperatureLoSP && bodyTemperature <= commonData.BodyTemperatureLoDB)
        {
            bodyTemperatureImage.color = flagColors.LColor;
        }
        else if (bodyTemperature >= commonData.BodyTemperatureLoLoSP && bodyTemperature <= commonData.BodyTemperatureLoLoDB)
        {
            bodyTemperatureImage.color = flagColors.LLColor;
        }
    }

    void UpdatePrimaryO2()
    {
        PrimaryOxygenSlider.value = bl_main.bl_scaling.scallingPrimaryOxygen() / 100;

        if(commonData.OxygenOneValue >commonData.PrimaryOxygenLoDB)
        {
            PrimaryO2Image.color = flagColors.HColor;
        }
        else if(commonData.OxygenOneValue <= commonData.PrimaryOxygenLoDB)
        {
            PrimaryO2Image.color = flagColors.LColor;
        }
    }

    void UpdateSecondaryO2()
    {

        Debug.Log(bl_main.bl_scaling.scallingSeondaryOxygen() / 100);
        SecondaryOxygenSlider.value = bl_main.bl_scaling.scallingSeondaryOxygen() / 100;

        if(commonData.OxygenTwoValue > commonData.SecondaryOxygenHiDB)
        {
            secondaryO2Image.color = flagColors.HHColor;
        }
        else if (commonData.SecondaryOxygenHiDB > commonData.OxygenTwoValue && commonData.OxygenTwoValue > commonData.SecondaryOxygenLoDB)
        {
            secondaryO2Image.color = flagColors.HColor;
        }
        else if(commonData.SecondaryOxygenLoDB > commonData.OxygenTwoValue && commonData.OxygenTwoValue > commonData.SecondaryOxygenLoLoDB)
        {
            secondaryO2Image.color = flagColors.LColor;
        }
        else if(commonData.OxygenTwoValue < commonData.SecondaryOxygenLoLoDB)
        {
            secondaryO2Image.color = flagColors.LLColor;
        } 
    }


    void UpdateDetailPiePanel()
    {
        //if (commonData.viewPieDetails)
        //{
        //    //detailedPie.SetActive(true);
        //    pie.SetActive(false);
        //}
        //else if (commonData.closePieDetails)
        //{
        //    //detailedPie.SetActive(false);
        //    pie.SetActive(true);
        //}
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
        if (commonData.viewWarnings)
        {
            DetailPanel.SetActive(true);
            commonData.viewWarnings = false;
        }
        else if (commonData.closeWarnings)
        {
            DetailPanel.SetActive(false);
            commonData.closeWarnings = false;
        }

        if(DetailPanel.active)
        {
            if(bl_main.bl_alarming.GetCurrentAlarm == null)
            {
                DetailPanel.SetActive(false);
            }
        }
    }
}

public static class ExtensionMethods
{
    public static float Map(this float value, float low1,float high1,float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }
}

