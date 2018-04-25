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
    public ColorCode pressureColors;

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
    }

    void UpdatePressureSlider()
    {
        float newPressurePosition = bl_main.bl_scaling.ScalingFunction().Map(0, 100, -66, 68);
        pressureFillImage.rectTransform.localPosition = new Vector3(newPressurePosition, 0f, 0f);

        float SuitPressure = commonData.SuitPressureValue;
        if (SuitPressure >= commonData.SuitPressHiHiDB && SuitPressure <= commonData.SuitPressHiHiSP)
        {
            pressureFillImage.color = pressureColors.LLColor;
        }
        else if (SuitPressure >= commonData.SuitPressHiDB && SuitPressure <= commonData.SuitPressHiSP)
        {
            pressureFillImage.color = pressureColors.LColor;
        }
        else if(SuitPressure <= commonData.SuitPressHiDB && SuitPressure >= commonData.SuitPressLoDB)
        {
            pressureFillImage.color = pressureColors.HColor;
        }
        else if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
        {
            pressureFillImage.color = pressureColors.LColor;
        }
        else if (SuitPressure >= commonData.SuitPressLoLoSP && SuitPressure <= commonData.SuitPressLoLoDB)
        {
            pressureFillImage.color = pressureColors.LLColor;
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
