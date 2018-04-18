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

    public UITask previousTask;
    public UITask currentTask;
    public UITask nextTask;

    public UITask GetPreviousTask { get { return previousTask; } }
    public UITask GetCurrentTask { get { return currentTask; } }
    public UITask GetNextTask { get { return nextTask; } }


    public bool viewPieDetails = false;
    public bool closePieDetails = false;
    public bool viewBattery = false;
    public bool viewPrimaryOTwo = false;
    public bool viewSecondaryOTwo = false;
    public bool viewBodyTemperature = false;
    public bool viewPressure = false;
    public bool viewHTwoO = false;
    public bool viewHeartRate = false;
    public bool closeDetailWindow = false;
    public bool pinDetailWindow = false;
    public bool closePinnedWindows = false;
    public bool viewErrors = false;
    public bool closeErrors = false;
    public bool nextError = false;
    public bool previousError = false;
    public bool viewWarnings = false;
    public bool closeWarnings = false;
    public bool nextWarning = false;
    public bool previousWarning = false;

    public bool startProcedure = false;
    public bool nextStep = false;
    public bool previousStep = false;
    public bool showStepImage = false;
    public bool hideStepImage = false;
    public bool pinTaskList = false;
    public bool closeTaskList = false;
    public bool loadTaskOne = false;
    public bool loadTaskTwo = false;


    //Health UI Values
    public float OxygenOneValue { get; set; }
    public float OxygenTwoValue { get; set; }
    public float HeartRateValue { get; set; }
    public float BodyTemperatureValue { get; set; }
    public float SuitPressureValue { get; set; }
    public float BatteryValue { get; set; }
    public float WaterValue { get; set; }


    public float SuitPressureMax { get; set; }
    public float SuitPressureMin { get; set; }

    public float SuitPressHiHiSP { get; set; }
    public float SuitPressHiHiDB { get; set; }

    public float SuitPressHiSP { get; set; }
    public float SuitPressHiDB { get; set; }

    public float SuitPressLoSP { get; set; }
    public float SuitPressLoDB { get; set; }

    public float SuitPressLoLoSP { get; set; }
    public float SuitPressLoLoDB { get; set; }


    //Task UI Values
    public string[][] PREVIOUS { get; set; }
    public string[][] CURRENT { get; set; }
    public string[][] NEXT { get; set; }

    public string[][] TASK_TABLE { get; set; }
}
