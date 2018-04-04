using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum consumableType
{
    Oxygen,
    Oxygen2,
    SuitPressure,
    Battery,
    BodyTemperature,
    Water,
    HeartRate
};

public class DB_GenerateData : MonoBehaviour {

    

    public consumableType type;
    public float min;
    public float max;
    public float threshold1;
    public float threshold1Percentage;
    public float threshold2;
    public float threshold2Percentage;
    public float initial;
    public float current;
    public float increment;
    public bool isActive;
    System.Random random = new System.Random();

    public CommonData commonData = CommonData.GetInstance();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch(type)
        {
            case consumableType.Water:
                commonData.WaterValue = current;
                break;
            case consumableType.Oxygen:
                commonData.OxygenOneValue = current;
                break;
            case consumableType.Oxygen2:
                commonData.OxygenTwoValue = current;
                break;
            case consumableType.Battery:
                commonData.BatteryValue = current;
                break;
            case consumableType.SuitPressure:
                commonData.SuitPressureValue = current;
                break;
            case consumableType.BodyTemperature:
                commonData.BodyTemperatureValue = current;
                break;
            case consumableType.HeartRate:
                commonData.HeartRateValue = current;
                break;

        }

        commonData.SuitPressureValue = current;

        //If the pipe has been deactivated return with out advancing
        if (!isActive)
        {
            return;
        }
       
        //Get random number between 0 and 100
        int nextRandom = random.Next(0, 101);

        //If less than first threshold subtract by increment amount
        if (nextRandom <= threshold1Percentage)
        {
            if (current - increment > min)
            {
                current -= increment;
            }
        }
        //Stay the same if between both thresholds
        else if (nextRandom <= 100.0f - threshold2Percentage)
        {

        }
        //If greater than second threshold add by increment amount
        else
        {
            if (current + increment < max)
            {
                current += increment;
            }
        }
    }
}
