using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public enum displayType
{
    Oxygen,
    OxygenTwo,
    SuitPressure,
    Battery,
    BodyTemperature,
    Water,
    HeartRate
}

public class DisplayDetails : MonoBehaviour
{
    public GameObject displaywindow;
    public Text title;
    public Text content;
    public CommonData commonData = CommonData.GetInstance();
    public BL_Main bl_main;

    public displayType displayingType;

    


    public void Display(string header, string values)
    {
        title.text = header;
        content.text = values;
        displaywindow.SetActive(true);
    }

    void Start()
    {
      
    }

    private void Update()
    {
        UpdateViewDetails();
    }

    void UpdateViewDetails()
    {
        switch(displayingType)
        {
            case displayType.SuitPressure:
                {
                    Display("Suit Pressure Details", "Pressure value " + bl_main.GetComponent<BL_Main>().bl_scaling.actualSuitPressure() + "PSI" + '\n' + '\n' + "Primary O2: " + (commonData.OxygenOneValue) + "psi" + '\n' + '\n' + "Secondary O2: " + (commonData.OxygenTwoValue) + "psi");
                    break;
                }
            case displayType.Oxygen:
                {
                    float Po2 = bl_main.bl_scaling.scallingPrimaryOxygen();
                    Po2 = Mathf.Round(Po2 * 100f) / 100; ;
                    Display("Primary Oxygen Details", "Primary O2 left: " + Po2 + "%" + '\n' + '\n' + "Primary O2: " + (commonData.OxygenOneValue) + "psi");
                    break;
                }
            case displayType.OxygenTwo:
                {
                    float So2 = bl_main.bl_scaling.scallingSeondaryOxygen();
                    So2 = Mathf.Round(So2 * 100f) / 100;
                    Display("Secondary Oxygen Details", "Secondary O2 left: " + So2 + "%" + '\n' + '\n' + "Secondary O2: " + (commonData.OxygenTwoValue) + "psi");
                    break;
                }
            case displayType.Battery:
                {
                    float bat = bl_main.bl_scaling.scallingBattery();
                    bat = Mathf.Round(bat * 100f) / 100;
                    Display("Battery Details", "Battery left: " + bat + "%");
                    break;
                }
            case displayType.BodyTemperature:
                {
                    Display("Temperature Details", "Body Temperature: " + (bl_main.bl_scaling.scallingBodyTemperature()) + " F");
                    break;
                }
            case displayType.HeartRate:
                {
                    Display("Heart Details", "Heart Rate: " + (bl_main.bl_scaling.scallingHeartRate()) + " bpm");
                    break;
                }
            case displayType.Water:
                {
                    float water = bl_main.bl_scaling.scallingWater();
                    water = Mathf.Round(water * 100f) / 100;
                    Display("H2O Details", "H2O left: " + water + "%" + '\n' + '\n' + "H2O :" + commonData.WaterValue + " lbs");
                    break;
                }
        }
    }
}
