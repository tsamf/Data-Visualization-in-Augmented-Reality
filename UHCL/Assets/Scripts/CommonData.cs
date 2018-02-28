using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonData {
    
    private static CommonData _commonData;

    private CommonData() { }

    public static CommonData GetInstance()
    {
        if(_commonData == null)
        {
            _commonData = new CommonData();
        }

        return _commonData;
    }

    //The common data  (flags and alarm definitions will go here)
    private bool editMode = false;
	public bool EditMode { get { return editMode; } set { editMode = value; } }


    //Health UI Values
    public float OxygenOneValue { get; set; }
    public float OxygenTwoValue { get; set; }
    public float HeartRateValue { get; set; }
    public float BodyTemperatureValue { get; set; }
    public float SuitPressureValue { get; set; }
    public float BatteryValue { get; set; }
    public float WaterValue { get; set; }
}
