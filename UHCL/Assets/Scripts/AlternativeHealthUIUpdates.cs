using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternativeHealthUIUpdates : MonoBehaviour {

    //public GameObject detailedPie;

    public GameObject displayDetails;
    public DisplayDetails dd;
    public BL_Main bl_main;

    public Image pressureFillImage;
    public Image heartRateImage;
    public Image bodyTemperatureImage;

    public Slider PrimaryOxygenSlider;
    public Image PrimaryO2Image;

    public Slider SecondaryOxygenSlider;
    public Image secondaryO2Image;

    public Image WaterImage;
    public Image BatteryImage;

    public ColorCode flagColors;

    public 

    CommonData commonData = CommonData.GetInstance();

    // Use this for initialization
    void Start()
    {
        //detailedPie.SetActive(false);
        
        displayDetails.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDetailPiePanel();
        UpdateViewDetails();
        UpdateSliders();
    }

    void UpdateSliders()
    {
        UpdatePressureSlider();
        UpdateHeartRateSlider();
        UpdateBodyTemperature();
        UpdatePrimaryO2();
        UpdateSecondaryO2();
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
        SecondaryOxygenSlider.value = bl_main.bl_scaling.scallingSeondaryOxygen() / 100;


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
            Debug.Log("view Pressure");
            dd.Display("Suit Pressure Details", "Pressure value " + bl_main.GetComponent<BL_Main>().bl_scaling.actualSuitPressure());

        }
        else if (commonData.closeDetailWindow)
        {
            displayDetails.SetActive(false);
            Debug.Log("CLose DEtail");
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
